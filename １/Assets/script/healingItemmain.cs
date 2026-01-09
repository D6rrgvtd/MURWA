using UnityEngine;

public class HealingItemMain : MonoBehaviour
{
    public float healAmount = 100f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeHealing(healAmount);
            }

            Destroy(gameObject);
        }
    }
}
