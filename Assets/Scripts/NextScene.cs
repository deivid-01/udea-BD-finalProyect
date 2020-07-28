using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{

    public static string teamSceneName="reg_team";
    public static string cyclistSceneName="reg_cyclist";

    public void LoadRegisterTeamScene ()
    {
        SceneManager.LoadScene ( teamSceneName );
    }

    public void LoadRegisterCyclistScene ()
    {
        SceneManager.LoadScene ( cyclistSceneName );
    }

}
