using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    // Singleton instance
    private static HealthController _instance;

    // Public property to access the singleton instance
    public static HealthController Instance
    {
        get
        {
            // If there is no instance, find it in the scene
            if (_instance == null)
            {
                _instance = FindObjectOfType<HealthController>();

                // If still null, create a new instance
                if (_instance == null)
                {
                    GameObject obj = new GameObject("HealthController");
                    _instance = obj.AddComponent<HealthController>();
                }
            }

            return _instance;
        }
    }

    public int PlayerHealth = 5;
    public int damage;

    [SerializeField] private Image[] hearts;

    void Start()
    {
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < PlayerHealth)
            {
                hearts[i].color = Color.red;
            }
            else
            {
                hearts[i].color = Color.black;
            }
        }

        if (PlayerHealth == 0)
        {
            GameOverSystemManager.lastScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene("GameOver");
        }
    }
}