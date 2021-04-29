using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StatsFramework;

public class HPBar : MonoBehaviour
{

    [SerializeField] 
    GameObject health;
    Stats StatsInfo;

    //implament code below to try get the inform from the health veriable in index 0
    //public int Health = StatsInfo.CharacterStats.GetValue(index); 

    //private void Start()
    //{
    //    //testing if the HP bar works
    //    health.transform.localScale = new Vector3(0.5f, 1f);
    //}

    //Set Hp
    public void SetHp(float hpNormalised)
    {
        health.transform.localScale = new Vector3(hpNormalised, 1f);
    }

    //animate the Hp falling over time
    public IEnumerator SetHPSmooth(float newHp)
    {
        float currentHp = health.transform.localScale.x;
        float changeAmount = currentHp - newHp;

        while (currentHp - newHp > Mathf.Epsilon)
        {
            currentHp -= changeAmount * Time.deltaTime;
            health.transform.localScale = new Vector3(currentHp, 1f);
            yield return null;
        }

        health.transform.localScale = new Vector3(newHp, 1f);
    }
}
