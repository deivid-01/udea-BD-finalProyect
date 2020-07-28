using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoosenTeam : MonoBehaviour
{

    private void OnMouseDown ()
    {
        ui_regCyclist.teamSelected = this.gameObject.transform.GetChild ( 0 ).GetComponent<Text> ().text;
    }

}
