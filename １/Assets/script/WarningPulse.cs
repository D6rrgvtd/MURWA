using UnityEngine;

public class WarningPulse : MonoBehaviour
{
    public float speed = 2f;
    public float minScale = 0.8f;
    public float maxScale = 1.2f;

    void Update()
    {
        float s = Mathf.Lerp(minScale, maxScale,
            (Mathf.Sin(Time.time * speed) + 1f) / 2f);

        transform.localScale = new Vector3(s, transform.localScale.y, s);
    }
}
