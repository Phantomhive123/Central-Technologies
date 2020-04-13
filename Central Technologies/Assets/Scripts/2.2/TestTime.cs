using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTime : MonoBehaviour
{
    private void OnGUI()
    {
        GUILayout.Space(20);
        GUILayout.Label("RealTime:" + Time.realtimeSinceStartup);
    }
}
