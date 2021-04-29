using UnityEngine;
using UnityEditor;
using StatsFramework;

[CustomEditor(typeof(Stats))]
public class EditorButton : Editor
{
    //this enables us to add a button to our script for testing in editor
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        //finding the target with stats
        Stats stats = (Stats)target;

        //selecting what the button should say
        if(GUILayout.Button("Click = Example in Console"))
        {
            //drawing the example from the stats script
            stats.Example();
        }
    }
}
