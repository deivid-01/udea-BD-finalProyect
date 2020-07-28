using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    public string nextScene;

    void Update()
    {
        if ( Input.anyKeyDown )
        {
            SceneManager.LoadScene ( nextScene );
        }
    }
}
