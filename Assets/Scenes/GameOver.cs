using UnityEngine;

public class GameOver : MonoBehaviour
{
    public AudioSource backgroundMusic; // Référence à l'AudioSource de la musique de fond
    public GameManagerScript gameManager; // Référence au GameManagerScript

    public void Start() {
        Time.timeScale = 1f;
    }

    // Méthode appelée lorsqu'un objet entre en collision avec cet objet
    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet en collision est le joueur
        if (other.CompareTag("Player"))
        {
            // Affiche un message de débogage pour vérifier la détection de collision
            Debug.Log("Player collided with obstacle");

            // Arrête la musique de fond
            if (backgroundMusic != null)
            {
                backgroundMusic.Stop();
                // Affiche un message de débogage pour vérifier l'arrêt de la musique
                Debug.Log("Background music stopped");
            }

            // Appelle une méthode pour gérer la fin de partie
            HandleGameOver();
        }
    }

    // Méthode pour gérer la fin de partie
    private void HandleGameOver()
    {
        // Affiche un message de débogage
        Debug.Log("Game Over!");

        // Arrête le jeu en mettant en pause le temps
        Time.timeScale = 0f;

        // Appelle la méthode GameOver du GameManagerScript
        if (gameManager != null)
        {
            gameManager.GameOver(); // Correction ici
        }
        else
        {
            Debug.LogWarning("GameManagerScript reference is not set!");
        }
    }
}
