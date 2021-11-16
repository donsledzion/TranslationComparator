using System.Collections.Generic;

class TranslationComparator
{
    private List<TranslationFile> _translationFiles;
    public TranslationComparator(List<string> paths)
    {
        _translationFiles = new List<TranslationFile>{};

        foreach(string path in paths){
            this._translationFiles.Add(new TranslationFile(path));
        }
    }

    public void ListTranslations(){
        foreach(TranslationFile translationFile in this._translationFiles){
            translationFile.ShowEntries();
        }
    }

    public void CompareTranslationFile(TranslationFile comparedFile){
        foreach(TranslationFile translationFile in this._translationFiles){
            if(!translationFile.Equals(comparedFile)){
                comparedFile.CompareToFile(translationFile);
            }
        }
    }    

    public void CompareTranslationFiles(){
        foreach(TranslationFile translationFile in this._translationFiles){
            this.CompareTranslationFile(translationFile);
        }
    }
}