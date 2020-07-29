using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreEnableButton : MonoBehaviour
{
    public GameObject btn1;
    public GameObject btn2;

    private void Update ()
    {
        if ( Input.GetMouseButtonDown ( 0 ) )
        {
           
            StartCoroutine( CheckEnable ( btn1 ));
            StartCoroutine( CheckEnable ( btn2 ));
        }


    }


    private IEnumerator CheckEnable (GameObject btn)
    {
        if ( !btn.activeInHierarchy )
        {
            yield return new WaitForSeconds ( 0.5f );
            btn.SetActive ( true );
            btn.GetComponent<ButtonActions> ().secondary.SetActive ( false );
        }
    }
}
