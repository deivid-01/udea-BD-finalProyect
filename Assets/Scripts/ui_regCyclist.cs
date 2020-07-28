using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ui_regCyclist : MonoBehaviour
{
    public InputField inputName;
    public InputField inputDateOfBirth;
    public InputField inputBrandBike;

    public static string teamSelected;
    
    public GameObject[] btnTeams;
    public  string[] teams;
     bool teamProccess;


    
    void Start()
    {
        teamProccess = false;
        LoadData ();
        EnableBtns ();
    }

    // Update is called once per frame
    public void LoadData () {

        var data=PlayerPrefs.GetString ( "teams","empty" );
        teams = data.Substring(0,data.Length-1).Split('-');

        if ( PlayerPrefs.GetInt ( "teamOn",0 ) ==1)
        {
            teamProccess = true;
        }
    }

    public void EnableBtns () {

        if ( teams[0].Equals("empty"))
        {
            return;  
        }

        for ( int i = 0 ;i < teams.Length ;i++ )
        {
            btnTeams [i].SetActive ( true );
            btnTeams [i].transform.GetChild ( 0 ).GetComponent<Text> ().text = teams [i];
        }

    }

    public void Back () {
       
        if ( teamProccess )
        {
            Data.instance.cyclists.Add ( new Cyclist ( inputName.text , inputDateOfBirth.text , inputBrandBike.text , PlayerPrefs.GetString("teamName") ) );
            SceneManager.LoadScene ( "reg_team" );
        }
        else
        {
            Data.instance.cyclists.Add ( new Cyclist ( inputName.text , inputDateOfBirth.text , inputBrandBike.text , teamSelected ) );

            SceneManager.LoadScene ( "Home" );
    

        }
    }


    public void ReadData () { 
    
    }
}
