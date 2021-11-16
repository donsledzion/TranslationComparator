using System;
using System.IO;
using System.Collections.Generic;
class TranslationFile{

    private string[] _lines;

    private List<Translation> _translations;

    public string Name;

    public TranslationFile(string pathToFile){
        this._lines = System.IO.File.ReadAllLines(@pathToFile);
        
        this.Name = Path.GetFileName(pathToFile);
        Console.WriteLine("Odczytywanie pliku \""+this.Name+"\"...");
        this._translations = new List<Translation>{};

        foreach(string line in this._lines){
            if(line.Contains("=")){
                
                string[] splittedLine = line.Split('=');
                string key = splittedLine[0];
                string value = splittedLine[1];
                this._translations.Add(new Translation(key,value));
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
    public void ShowEntries(){
        foreach(Translation translation in this._translations){            
            Console.WriteLine(translation);
        }
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



    

}