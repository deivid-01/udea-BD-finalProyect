using Packages.Rider.Editor.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
public class ui_regTeam : MonoBehaviour
{
    public GameObject[] btns;
    int actualbtn;
    public string sceneNameRegCyc;
    public string previusScene;

    public InputField inputName;
    public InputField inputCity;
    public InputField inputCouchName;

    string[] indexs;

    private void Start ()
    {
        LoadData ();
        DisableBtns ();
        actualbtn = 5;

        //LOAD BTNS STILL INTERACTABLE
    }

    public void LoadData () {
        var data=PlayerPrefs.GetString("dataTeam");
        if ( data.Equals ( "" ) )
        {
            return;
        }
        string[]inputsData=data.Substring(0,data.Length-1).Split('-');
        inputName.text = inputsData [0];
        inputCity.text = inputsData [1];
        inputCouchName.text = inputsData [2];
}

    public void DisableBtns () {
        var data= PlayerPrefs.GetString("btnsDone","empty");
        if ( data.Equals ( "empty" ) )
        {
            return;
        }
        
        indexs = data.Substring(0,data.Length-1).Split ( '-' );

        foreach ( string index in indexs )
        {
            btns [int.Parse ( index )].GetComponent<Button> ().interactable = false;
        }
    }

    public void  ActiveBtn () {
        if ( actualbtn < btns.Length  )
        {
            btns [actualbtn].SetActive ( true );
            ++actualbtn;
        }
    }

    public void LoadScene (string index) {
        if ( inputName.text.Length == 0 )
        {
            return;
        }
        else
        {
            //MAKE BTNS NO INTERACTABLE
        PlayerPrefs.SetString ( "btnsDone" , PlayerPrefs.GetString("btnsDone")+index +"-");
         PlayerPrefs.SetString ("teams", inputName.text+"-");
            PlayerPrefs.SetInt ( "teamOn" , 1 );


            PlayerPrefs.SetString ( "teamName" , inputName.text );
            PlayerPrefs.SetString ( "dataTeam" , inputName.text +"-"+ inputCity.text + "-" + inputCouchName.text+"-" );
        SceneManager.LoadScene ( sceneNameRegCyc );
        } 
    }

    public void Done () {
        if ( ValidateInteractable () )
        {
            //Create team;
            Data.instance.team = new Team ( inputName.text , inputCity.text , inputCouchName.text );

            //Send to dataBase
            Data.instance.AddTeamDB();

        }
    }

    public void Back () {

        SceneManager.LoadScene ( previusScene );
    }


    public bool ValidateInteractable () {

        int cont=0;
        foreach ( GameObject go in btns )
        {
            if (! go.GetComponent<Button> ().IsInteractable ())
            {
                ++cont;
            }
                
        }

        if ( cont >= 1 )
        {
            return true;
        }
        return false;
    }
}
