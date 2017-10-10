using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClassBase {

    public int iID = 0;
    public string strName = "";

    public ClassBase()
    {
        iID = 1;
        strName = "Example";
    }

    public ClassBase(int ID, string Name)
    {
        iID = ID;
        strName = Name;
    }

    public override string ToString()
    {
        return "ID = " + iID.ToString() + "; Name = " + strName;
    }
}
