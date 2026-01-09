using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("体力")]
    public float maxHealth = 100f;
    private float currentHealth;

    [Header("ドロップアイテム")]
    public GameObject healingItemPrefab;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log($"{gameObject.name}のHP: {currentHealth}/{maxHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }


    void Die()
    {
        Debug.Log($"{gameObject.name}が死亡！");
        GameManager.instance.AddKillcount();

        TryDropItem();

        Destroy(gameObject);
    }
    void TryDropItem()
    {
        float chance =  Random.value;
        if (chance <= 0.3f)//30%
        {
            Instantiate(healingItemPrefab, transform.position,Quaternion.identity);
            Debug.Log("回復アイテムをドロップ!");
        }
    }
}
