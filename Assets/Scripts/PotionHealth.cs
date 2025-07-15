using UnityEngine;

public class PotionHealth : MonoBehaviour
{
    public int healAmount = 25;
    private PotionManager potionManager;

    void Start()
    {
        potionManager = FindObjectOfType<PotionManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth player = collision.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.Heal(healAmount);

            // Tambahkan baris ini untuk update UI
            if (potionManager != null)
            {
                potionManager.CollectPotion();
            }

            Destroy(gameObject); // Potion hilang setelah disentuh player
        }
    }
}
