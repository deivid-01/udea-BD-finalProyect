using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyclist
{
    public string name;
    public string dateOfBirth;
    public string brandBike;
    public string idTeam;
    public string teamName;

    public Cyclist ( string name , string dateOfBirth , string brandBike  , string teamName )
    {
        this.name = name;
        this.dateOfBirth = dateOfBirth;
        this.brandBike = brandBike;
        this.teamName = teamName;
    }
}