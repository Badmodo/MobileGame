using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatsFramework
{
    public class Stats : MonoBehaviour
    {
        //starting with 5 
        public StatsInfo[] CharacterStats = new StatsInfo[5];
       
        //for use in the editor button
        public void Example()
        {
            //the message to appear in the console on pressing button in EditorButton
            Debug.Log("Stat - Health 10 / Attack 5 / Defence 8 / Speed 10 / Agility 5 ");
        }
    }

    //the types of data able to be input into the arrays
    [System.Serializable]
    public class StatsInfo
    {
        public String Stat;
        public int Level = 0;
    }
}