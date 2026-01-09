using UnityEngine;

public class BoundaryWarningTrigger : MonoBehaviour
{
    public Renderer read;
    public Color nearColor = Color.red;
    public Color farColor = Color.yellow;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            read.material.color = nearColor;
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
            read.material.color = farColor;
    }
}
