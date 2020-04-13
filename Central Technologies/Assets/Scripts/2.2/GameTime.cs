using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    private void OnGUI()
    {
        GUILayout.Label("Time Scale:" + Time.timeScale);
        Time.timeScale = GUILayout.HorizontalSlider(Time.timeScale, 0, 2, GUILayout.Width(200));
        GUILayout.Space(20);

        GUILayout.Label("Real Time:" + Time.realtimeSinceStartup);
        GUILayout.Label("Game Time:" + Time.time);
        GUILayout.Space(20);
    }

    private void Update()
    {
        Debug.Log("TimeScale:" + Time.timeScale + "\n" +
            "DeltaTime:" + Time.deltaTime + "\n" +
            "UnscaledTime:" + Time.unscaledDeltaTime + "\n" +
            "Smooth Time:" + Time.smoothDeltaTime);
    }
}
