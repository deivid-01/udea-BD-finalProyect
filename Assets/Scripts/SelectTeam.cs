using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectTeam : MonoBehaviour
{

    public void AsignarEquipo () {
        ui_regCyclist.teamSelected = this.transform.GetChild ( 0 ).GetComponent<Text> ().text;
        Debug.Log ( this.transform.GetChild ( 0 ).GetComponent<Text> ().text );
    }
}
