using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class search_team : MonoBehaviour
{

    public string searchBy;

    public GameObject table;

    public List<DataTeam> dataTeams;

    public Rows[] grid;


    void Start()
    {
        dataTeams = new List<DataTeam> ();

        searchBy = PlayerPrefs.GetString ( "searchBy" );
    }

    void Update()
    {
        
    }

    public void Search (InputField search) {

        StartCoroutine ( Search_team ( search.text ) );

    }

   IEnumerator Search_team (string word) {

        WWWForm form = new WWWForm ();
        form.AddField ( "searchby" , searchBy );
        form.AddField ( "word" , word );

        UnityWebRequest www = UnityWebRequest.Post ( "http://localhost/sqlconnect/get_teams.php" , form );

        yield return www.SendWebRequest ();

   
        var result = www.downloadHandler.text;
        if ( result != "-1" )
        {
            SetDataTeam (result);
        }
        else
        {
            Debug.Log ( www.downloadHandler.text );
        }
    }

    public void SetDataTeam ( string alldata )
    {
        string [] cyclistsdata = alldata.Substring ( 0 , alldata.Length - 1 ).Split ( '\t' );

        foreach ( string cyclist in cyclistsdata )
        {
            SetDataCyclist ( cyclist );
        }

        LoadInfoToGrid ();
    }



    public void SetDataCyclist ( string data )
    {
        DataTeam newTeam;

        string [] eachAtributo = data.Split ( '-' );

        newTeam.id = eachAtributo [0];
        newTeam.name = eachAtributo [1];
        newTeam.city = eachAtributo [2];
        newTeam.coach = eachAtributo [3];
        newTeam.regdate = eachAtributo [4];
        

        dataTeams.Add ( newTeam );
    
    }

    public void LoadInfoToGrid () {

 

        for ( int i = 0 ;i < dataTeams.Count+1 ;i++ )
        {
            for ( int j = 0 ;j < grid[i].objs.Length ;j++ )
            {
                grid [i].objs [j].SetActive ( true );

                if ( i > 0 )
                {
                    if ( j == 0 )
                        grid [i].objs [j].transform.GetChild ( 0 ).GetComponent<Text> ().text = dataTeams [i - 1].id;
                    else if ( j == 1 )
                        grid [i].objs [j].transform.GetChild ( 0 ).GetComponent<Text> ().text = dataTeams [i - 1].name;
                    else if ( j == 2 )
                        grid [i].objs [j].transform.GetChild ( 0 ).GetComponent<Text> ().text = dataTeams [i - 1].city;
                    else if ( j == 3 )
                        grid [i].objs [j].transform.GetChild ( 0 ).GetComponent<Text> ().text = dataTeams [i- 1].coach;
                    else if ( j == 4 )
                        grid [i].objs [j].transform.GetChild ( 0 ).GetComponent<Text> ().text = dataTeams [i - 1].regdate;
                }

            }
        }
    }

    public void DeleteTeam ( Text id )
    {
        StartCoroutine ( DeleteFromDb ( id.text ) );
    }

    IEnumerator DeleteFromDb ( string id )

    {
        WWWForm form = new WWWForm ();
        form.AddField ( "id" , id );

        UnityWebRequest www = UnityWebRequest.Post ( "http://localhost/sqlconnect/delete_team.php" , form );

        yield return www.SendWebRequest ();

        var result = www.downloadHandler.text;

        if ( result != "-1" )
        {
            SceneManager.LoadScene ( "Home" );
        }
        else
        {
            Debug.Log ( www.downloadHandler.text );
        }

    }





    public struct DataTeam {

        public string id;
        public string name;
        public string city;
        public string coach;
        public string regdate;

    }

}
