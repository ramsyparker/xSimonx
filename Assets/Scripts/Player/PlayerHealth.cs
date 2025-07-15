using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 50;
    public Slider healthBar;

    public GameObject gameOverPanel; // Panel Game Over
    public Button retryButton;       // Tombol Retry

    void Start()
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        if (retryButton != null)
            retryButton.onClick.AddListener(RestartGame);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            ShowGameOver();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.value = currentHealth;
    }

    void ShowGameOver()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        Time.timeScale = 0f;
    }

    void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
