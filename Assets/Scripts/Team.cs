using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team
{
    public string name;
    public string city;
    public string couchName;

    public Team ( string name , string city , string couchName )
    {
        this.name = name;
        this.city = city;
        this.couchName = couchName;
    }
}
