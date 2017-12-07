using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVarsReset : MonoBehaviour {
    public void ResetGlobalVars()
    {
        GlobalControl.Instance.SendMessage("ResetPlayerState");
    }
}
