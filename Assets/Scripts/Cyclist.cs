using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyclist
{
    public string name;
    public string lastname;
    public string dateOfBirth;
    public string brandBike;
    public string idTeam;
    public string teamName;

    public Cyclist ( string name , string lastname, string dateOfBirth , string brandBike  , string teamName )
    {
        this.name = name;
        this.lastname = lastname;
        this.dateOfBirth = dateOfBirth;
        this.brandBike = brandBike;
        this.teamName = teamName;
    }
}