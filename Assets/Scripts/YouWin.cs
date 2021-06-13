using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWin : MonoBehaviour
{
    public GameObject youWin;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        youWin.SetActive(true);
    }

    public void Restart()
    {
        Debug.Log("Restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Destroy(player);
    }

    public void NextLevel()
    {
        Debug.Log("NextLevel");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
