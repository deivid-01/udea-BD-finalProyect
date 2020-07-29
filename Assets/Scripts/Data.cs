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





    public Team team;

    public Cyclist cyclist;

    public List<Cyclist> cyclists=new List<Cyclist>();

    private void Awake ()
    {
        if ( instance is null )
        {
            DontDestroyOnLoad ( this.gameObject );
            instance = this;
        }


    }

    #endregion

    public void AddTeamDB ()
    {
        StartCoroutine ( SendTeamDB () );
    }
    IEnumerator SendTeamDB ()
    {
   


        WWWForm form = new WWWForm ();
        form.AddField ( "name" , team.name );
        form.AddField ( "city" , team.city );
        form.AddField ( "coach" , team.couchName );
        form.AddField ( "regdate" , DateTime.Now.ToShortDateString () ); //DateTime.Now.ToString()
        UnityWebRequest www = UnityWebRequest.Post ( "http://localhost/sqlconnect/register_team.php" , form );
        yield return www.SendWebRequest ();

        var result = www.downloadHandler.text;
        if ( result != "-1" )
        {

            Debug.Log ( result );
            AddCyclistDB ( result );
        }
        else
        {
            Debug.Log ( www.downloadHandler.text );

        }









    }

    public void AddCyclistDB ( string id ) {

        foreach ( Cyclist c in cyclists )
        {
            c.idTeam = id;
            StartCoroutine ( RegisterCyclists ( c ) );

        }




    }

    public static IEnumerator RegisterCyclists ( Cyclist c )


    {
        WWWForm form = new WWWForm ();
        form.AddField ( "name" , c.name );
        form.AddField ( "lastname" , c.lastname );
        form.AddField ( "birthdate" , c.dateOfBirth );
        form.AddField ( "regdate" , DateTime.Now.ToShortDateString () );
        form.AddField ( "bikebrand" , c.brandBike );
        form.AddField ( "idteam" , c.idTeam );

        UnityWebRequest www = UnityWebRequest.Post ( "http://localhost/sqlconnect/register_cyclist.php" , form );

        yield return www.SendWebRequest ();

        var result = www.downloadHandler.text;
        if ( result == "0" )
        {
            Debug.Log ( "Created Cyclist Success" );


        }
        else
        {
            Debug.Log ( www.downloadHandler.text );

        }
    }







}
