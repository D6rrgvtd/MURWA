using UnityEngine;

public class WeaponSpawnEffect : MonoBehaviour
{
    [Header("生成時に表示するエフェクト")]
    public GameObject effectPrefab;

    [Header("エフェクトの生存時間")]
    public float effectDuration = 3f;

    void Start()
    {
        if (effectPrefab != null)
        {
            GameObject effect = Instantiate(
                effectPrefab,
                transform.position,
                Quaternion.identity
            );

            Destroy(effect, effectDuration);
        }
    }
}
