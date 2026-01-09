using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneChanger : MonoBehaviour
{
    public GameObject flowerParticle;
    private float Change = 4.5f;

    void Start()
    {
        StartCoroutine(Scenenext());
    }
    public void ShowClearEffect()
    {
        flowerParticle.SetActive(true);
    }
    IEnumerator Scenenext()
    {
        yield return new WaitForSeconds(Change);

        SceneManager.LoadScene("Result");
    }
}
