using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalActions : MonoBehaviour
{
    public GameObject searchbyTeam;
    public GameObject disable;

    public GameObject searchByCyclist;
 



    public void ShowTeamSearchBy()

    {
        disable.SetActive ( false );
        searchbyTeam.SetActive ( true );


    }


    public void ShowCyclistSearchBy ()

    {
        disable.SetActive ( false );
        searchByCyclist.SetActive ( true );
    }

    public void SearchByTeamSelected ( string searchby )
    {
        PlayerPrefs.SetString ( "searchBy" , searchby );
        SceneManager.LoadScene ( "Search_team" );
    }

    public void SearchByCyclistSelected ( string searchby )
    {
        Debug.Log ( "WHats wrooog" );
        PlayerPrefs.SetString ( "searchBy" , searchby );
        SceneManager.LoadScene ( "Search_cycle" );
    }
}
