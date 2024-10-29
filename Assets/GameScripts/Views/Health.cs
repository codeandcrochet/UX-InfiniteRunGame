using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // For loading scenes

namespace Assets.GameScripts.Views
{
    public class HealthManager : MonoBehaviour
    {
        public int maxHealth = 3;
        private int currentHealth;

        public Image[] hearts;
        public Sprite fullHeart;
        public Sprite emptyHeart;

        void Start()
        {
            currentHealth = maxHealth;
            UpdateHearts();
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            UpdateHearts();

            // Check if health has reached zero
            if (currentHealth <= 0)
            {
                GameOver();
            }
        }

        public void Heal(int healAmount)
        {
            currentHealth += healAmount;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            UpdateHearts();
        }

        private void UpdateHearts()
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                hearts[i].sprite = i < currentHealth ? fullHeart : emptyHeart;
            }
        }

        private void GameOver()
        {
            // Load the "Game Over" scene
            SceneManager.LoadScene("GameOver"); // Make sure this matches your scene's name exactly
        }
    }
}