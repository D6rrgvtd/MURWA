using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameclear : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.clearTime = Time.timeSinceLevelLoad;
            SceneManager.LoadScene("Clear");
        }
    }
}
