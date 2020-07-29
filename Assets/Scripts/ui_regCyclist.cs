using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
public class ui_regCyclist : MonoBehaviour
{

    public struct TeamData {

        public string name;
        public string id;
    } 


    public InputField inputName;
    public InputField inputLastName;
    public InputField inputDateOfBirth;
    public InputField inputBrandBike;

    public static string teamSelected="";

    
    public GameObject[] btnTeams;
    public  string[] teams;
     bool teamProccess;

    public string[] teamsData;
    public List<TeamData> teamsInfo;
 
    public GameObject teamSection;


    
    void Start()
    {
        teamsInfo = new List<TeamData> ();

        teamProccess = false;
        LoadData ();
  

        if ( teamProccess )
        {
            teamSection.SetActive ( false );
        }
    }

    // Update is called once per frame
    public void LoadData () {

        //Get teams names from data base

        StartCoroutine(GetTeamsNames ());

        if ( PlayerPrefs.GetInt ( "teamOn",0 ) ==1)
        {
            teamProccess = true;
        }
    }

    IEnumerator GetTeamsNames () {

        UnityWebRequest www = UnityWebRequest.Get ( "http://localhost/sqlconnect/get_teamnames.php" );
        
            yield return www.SendWebRequest ();

        var result = www.downloadHandler.text;
        teamsData=result.Substring(0,result.Length-1).Split ( '\t' );
        foreach ( string  s in teamsData )
        {
            string []info = s.Split ( '-' );
            TeamData td;
            td.id = info [0];
            td.name = info [1];
            teamsInfo.Add ( td );
        }


        EnableBtns ();
            


    }

    public void EnableBtns () {


        for ( int i = 0 ;i < teamsInfo.Count;i++ )
        {
            btnTeams [i].SetActive ( true );
            btnTeams [i].transform.GetChild ( 0 ).GetComponent<Text> ().text = teamsInfo[i].name;
        }

    }

    public void Back () {
       
        if ( teamProccess )
        {
            

            Data.instance.cyclists.Add ( new Cyclist ( inputName.text , inputLastName.text ,inputDateOfBirth.text , inputBrandBike.text , PlayerPrefs.GetString("teamName") ) );


            SceneManager.LoadScene ( "reg_team" );
        }
        else
        {
            
            if ( teamSelected.Length > 0 )
            {
                Cyclist newCyclist=  new Cyclist ( inputName.text , inputLastName.text ,
                            inputDateOfBirth.text , inputBrandBike.text , teamSelected );

                newCyclist.idTeam = SetIdToCyclist ();

                StartCoroutine ( Data.RegisterCyclists ( newCyclist ) );
                
            } 

            

            SceneManager.LoadScene ( "Home" );
    

        }
    }

    public string SetIdToCyclist () {
        foreach ( TeamData teamData in teamsInfo )
        {
            if ( teamData.name == teamSelected )
            {
                return teamData.id;
            }
        }

        return null;

    }


    public void ReadData () { 
    
    }
}
