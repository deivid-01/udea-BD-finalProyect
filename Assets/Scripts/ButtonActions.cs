using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{
    
    public GameObject secondary;

    public void Start ()
    {
        PlayerPrefs.DeleteAll ();
    }

    public void  ShowSecondary () {

        if ( this.gameObject.activeInHierarchy )
        {
            this.gameObject.SetActive ( false );
            secondary.SetActive ( true );
        }
    }

   


}
