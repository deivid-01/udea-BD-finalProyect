using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class DataBaseController : MonoBehaviour
{
    public InputField name;
    public InputField lastname;

    public void CallRegister () {

        StartCoroutine ( AddInfo () );
    }

    IEnumerator AddInfo ()
    {
        WWWForm form = new WWWForm();
        form.AddField ( "name" , name.text );
        form.AddField ( "lastname" , lastname.text );
        UnityWebRequest www=  UnityWebRequest.Post("http://localhost/sqlconnect/register.php",form);
        yield return www.SendWebRequest();
        if ( www.isNetworkError || www.isHttpError )
        {
            Debug.Log (www.error );
        }
        else
        {
            Debug.Log ( "User creation success" );


        }
    }
}
