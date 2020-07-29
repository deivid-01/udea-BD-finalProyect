using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class search_cyclist : MonoBehaviour
{

    public string searchBy;

    public GameObject table;

    public List<DataCyclist> dataCyclists;

    public Rows[] grid;


    void Start()
    {
        dataCyclists = new List<DataCyclist> ();


        searchBy = PlayerPrefs.GetString ( "searchBy" );
    }

    void Update()
    {
        
    }

    public void Search (InputField search) {

        StartCoroutine ( Search_cyclist ( search.text ) );

    }

   IEnumerator Search_cyclist (string word) {

        WWWForm form = new WWWForm ();
        form.AddField ( "searchby" , searchBy );
        form.AddField ( "word" , word );

        UnityWebRequest www = UnityWebRequest.Post ( "http://localhost/sqlconnect/get_cyclists.php" , form );

        yield return www.SendWebRequest ();

   
        var result = www.downloadHandler.text;
        if ( result != "-1" )
        {
            SetDataCyclists (result);
        }
        else
        {
            Debug.Log ( www.downloadHandler.text );
        }
    }

    public void SetDataCyclists ( string alldata )
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
        DataCyclist newCyclist;

        string [] eachAtributo = data.Split ( '-' );

        newCyclist.id = eachAtributo [0];
        newCyclist.name = eachAtributo [1];
        newCyclist.lastname = eachAtributo [2];
        newCyclist.birthdate = eachAtributo [3];
        newCyclist.regdate = eachAtributo [4];
        newCyclist.brandbike = eachAtributo [5];

        dataCyclists.Add ( newCyclist );
    
    }

    public void LoadInfoToGrid () {

 

        for ( int i = 0 ;i < dataCyclists.Count+1 ;i++ )
        {
            for ( int j = 0 ;j < grid[i].objs.Length ;j++ )
            {
                grid [i].objs [j].SetActive ( true );

                if ( i > 0 )
                {
                    if ( j == 0 )
                        grid [i].objs [j].transform.GetChild ( 0 ).GetComponent<Text> ().text = dataCyclists [i - 1].id;
                    else if ( j == 1 )
                        grid [i].objs [j].transform.GetChild ( 0 ).GetComponent<Text> ().text = dataCyclists [i - 1].name;
                    else if ( j == 2 )
                        grid [i].objs [j].transform.GetChild ( 0 ).GetComponent<Text> ().text = dataCyclists [i - 1].lastname;
                    else if ( j == 3 )
                        grid [i].objs [j].transform.GetChild ( 0 ).GetComponent<Text> ().text = dataCyclists [i- 1].birthdate;
                    else if ( j == 4 )
                        grid [i].objs [j].transform.GetChild ( 0 ).GetComponent<Text> ().text = dataCyclists [i - 1].regdate;
                    else if ( j == 5 )
                        grid [i].objs [j].transform.GetChild ( 0 ).GetComponent<Text> ().text = dataCyclists [i- 1].brandbike;
                }

            }
        }
    }


    public struct DataCyclist {

        public string id;
        public string name;
        public string lastname;
        public string birthdate;
        public string regdate;
        public string brandbike;
    }

}
