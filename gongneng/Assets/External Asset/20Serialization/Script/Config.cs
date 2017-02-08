using UnityEngine;
using System.Collections;

[System.Serializable]
public class Config
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    private string id;

    public string Id
    {
        get { return id; }
        set { id = value; }
    }


}
