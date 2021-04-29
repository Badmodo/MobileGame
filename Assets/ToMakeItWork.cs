using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMakeItWork : MonoBehaviour
{
    public GameObject Player;

    private void Awake()
    {
        StartCoroutine(TurnItOffAndOnAgain());
    }

    public IEnumerator TurnItOffAndOnAgain()
    {
        yield return new WaitForSeconds(.1f);
        Player.SetActive(false);
        yield return new WaitForSeconds(.1f);
        Player.SetActive(true);
    }
}
