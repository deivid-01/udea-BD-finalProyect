using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Networking;

public class Data : MonoBehaviour
{
    #region Singlenton
    public static Data instance;
    private void Awake ()
    {
        if ( instance is null )
        {
            DontDestroyOnLoad ( this.gameObject );
            instance = this;
        }
        

    }

    private void Start ()
    {
        Debug.Log ( DateTime.Now.ToShortDateString () );
    }
    #endregion


    public Team team;

    public Cyclist cyclist;

    public List<Cyclist> cyclists=new List<Cyclist>();

    public  void AddTeamDB ()
    {
        StartCoroutine ( SendTeamDB () );
    }
    IEnumerator SendTeamDB ()
    {
        #region Register Team


        WWWForm form = new WWWForm();
        form.AddField ( "name" , team.name);
        form.AddField ( "city" , team.city);
        form.AddField ( "coach" , team.couchName);
        form.AddField ( "regdate" , DateTime.Now.ToShortDateString()); //DateTime.Now.ToString()
        UnityWebRequest www=  UnityWebRequest.Post("http://localhost/sqlconnect/register_team.php",form);
        yield return www.SendWebRequest ();
        if ( www.downloadHandler.text == "0" )
        {
            Debug.Log ( "Team  creation success" );
            AddCyclistDB ();
        }
        else
        {
            Debug.Log ( www.downloadHandler.text );
            Debug.Log ( www.downloadHandler.data );

        }
       // if ( www.isNetworkError || www.isHttpError )
    
        

      

   

     #endregion


    }

    public void AddCyclistDB () { 

        //SEARCH TEAM NAME ON DB, GET AND ASIGGN ID NUMBER TO ID CYCLLIST TEAM    
    }
}
