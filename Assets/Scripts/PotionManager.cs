using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PotionManager : MonoBehaviour
{
    public TextMeshProUGUI potionUIText;
    public GameObject nextLevelPanel; // Panel UI untuk "Next Level"

    private int totalPotion;
    private int collectedPotion = 0;

    void Start()
    {
        totalPotion = GameObject.FindGameObjectsWithTag("Potion").Length;
        UpdatePotionText();

        if (nextLevelPanel != null)
            nextLevelPanel.SetActive(false); // Panel disembunyikan saat awal
    }

    public void CollectPotion()
    {
        collectedPotion++;
        UpdatePotionText();

        if (collectedPotion >= totalPotion)
        {
            ShowNextLevelPanel();
        }
    }

    void UpdatePotionText()
    {
        potionUIText.text = "Ramuan:\n" + collectedPotion + " / " + totalPotion;
    }

    void ShowNextLevelPanel()
    {
        if (nextLevelPanel != null)
        {
            nextLevelPanel.SetActive(true);
            Time.timeScale = 0f; // Pause game
        }
    }

    public void LoadNextScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
