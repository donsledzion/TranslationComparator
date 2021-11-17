using System.Collections.Generic;

class TranslationComparator
{
    private List<TranslationFile> _translationFiles;

    private Dictionary<Translation, string> _mismatches;

    private List<Translation> _doubles; 
    public TranslationComparator(List<string> paths)
    {
        _translationFiles = new List<TranslationFile>{};
        _mismatches = new Dictionary<Translation, string> { };
        _doubles = new List<Translation> { };
        foreach(string path in paths){
            this._translationFiles.Add(new TranslationFile(path));
        }
    }

    public Dictionary<Translation, string> GetMismatches()
    {
        return this._mismatches;
    }

    public List<Translation> GetDoubles()
    {
        return this._doubles;
    }


    public Dictionary<Translation, string> CompareTranslationFile(TranslationFile comparedFile){
        foreach(TranslationFile translationFile in this._translationFiles){
            if(!translationFile.Equals(comparedFile)){
                List<Translation> mismatchesFound = comparedFile.CompareToFile(translationFile);
                List<Translation> doublesFound = comparedFile.FindDoubles(translationFile);
                foreach (Translation mismatchFound in mismatchesFound)
                {
                    _mismatches.Add(mismatchFound, comparedFile.Name);
                }
                foreach (Translation doubleFound in doublesFound) {
                    if (!KeyExistsOnList(doubleFound.GetKey(), this._doubles))
                    {
                        this._doubles.Add(doubleFound);
                    }
                }
            }
        }
        return this.GetMismatches();
    }    

    public void CompareTranslationFiles(){
        foreach(TranslationFile translationFile in this._translationFiles){
            this.CompareTranslationFile(translationFile);
        }        
    }

    public static bool KeyExistsOnList(string key, List<Translation> translations)
    {
        foreach (Translation translation in translations) {
            if (translation.GetKey() == key) {
                return true;
            }
        }
        return false;
    }


}