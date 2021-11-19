using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
class TranslationFile{

    private string[] _lines;

    private string _fullPath;

    private List<Translation> _translations;

    public string Name;



    public TranslationFile(string pathToFile){
        this._lines = System.IO.File.ReadAllLines(@pathToFile);
        this._fullPath = pathToFile;
        this.Name = Path.GetFileName(pathToFile);
        this._translations = new List<Translation>{};

        foreach(string line in this._lines){
            if(line.Contains("=")){
                this._translations.Add(new Translation(line));
            }
        }
    }

    public bool EqualsTo(TranslationFile translationFile){
        if(this.Name == translationFile.Name){
            return true;
        }
        return false;
    }
    public List<Translation> GetTranslations(){
        return this._translations;
    }

    public bool KeyExists(string key){
        foreach(Translation translation in this._translations){
            if(translation.GetKey() == key){
                return true;
            }
        }        
        return false;
    }

    public bool TranslationIsDoubled(Translation otherTranslation) {
        foreach (Translation translation in this._translations) {
            if (otherTranslation.Equals(translation)) {
                return true;
            }
        }
        return false;
    }

    public List<Translation> FindDoubles(TranslationFile translationFile) {
        List<Translation> doubles = new List<Translation> { };
        foreach (Translation otherTranslation in translationFile.GetTranslations())
        {
            if (TranslationIsDoubled(otherTranslation))
            {
                doubles.Add(otherTranslation);
            }
        }
        return doubles;
    }

    public List<Translation> CompareToFile(TranslationFile translationFile){

        List<Translation> mismatches = new List<Translation> { };
        

        foreach(Translation otherTranslation in translationFile.GetTranslations()){

            if (!KeyExists(otherTranslation.GetKey())) {
                mismatches.Add(otherTranslation);
            } 
        }
        return mismatches;
    }

    public void ChangeValue(Translation translation, string newValue)
    {
        string[] arrLine = File.ReadAllLines(this._fullPath);
        arrLine[GetLineNumberInFile(translation) - 1] = translation.GetKey()+"="+newValue;
        File.WriteAllLines(this._fullPath, arrLine);
    }

    public int GetLineNumberInFile(Translation translation, StringComparison comparison = StringComparison.CurrentCulture)
    {
        int lineNumber = 0;
        using (StringReader reader = new StringReader(File.ReadAllText(this._fullPath)))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                lineNumber++;
                if (line.Equals(translation.ToString()))
                    return lineNumber;
            }
        }
        return -1;
    }

    public Translation GetTranslationByKey(string key)
    {
        if (KeyExists(key))
        {
            foreach (Translation translation in this._translations)
            {
                if (translation.GetKey() == key)
                {
                    return translation;
                }
            }
        }
        return null;
    }



}