class Translation
{
    private string _key;
    private string _value;

    public Translation(string key, string value)
    {
        this._key = key;
        this._value = value;
    }

    public Translation(string line)
    {
        string[] splittedLine = line.Split('=');
        string key = splittedLine[0];
        string value = splittedLine[1];
        this._key = key;
        this._value = value;
    }

    public string GetKey(){return this._key;}
    public string GetValue(){return this._value;}

    public override string ToString(){return this._key+"="+this._value;}

    protected void SetKey(string key){this._key = key;}

    protected void SetValue(string value){this._value = value;}

    public bool Equals(Translation translation)
    {
        if((this._key != translation._key)||(this._value != translation._value)){
            return false;
        }
        return true;
    }

    

}