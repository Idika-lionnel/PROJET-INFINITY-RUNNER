using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject player; // Référence au joueur pour réinitialiser sa position

    // Méthode appelée lorsque le bouton Restart est cliqué
    public void RestartGame()
    {
        // Réinitialise le score directement sans passer par ScoreManager
        ScoreManager.scoreValue = 0;

        // Réinitialise la position du joueur
        if(player != null)
        {
            player.transform.position = Vector3.zero; // Réinitialise à la position d'origine
        }

        // Réinitialise d'autres états du jeu si nécessaire

        // Recharge la scène actuelle pour redémarrer le jeu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Méthode appelée lorsque le bouton Quit est cliqué
    public void QuitGame()
    {
        // Quitte l'application (fonctionne uniquement dans les builds standalone)
        Application.Quit();
    }

    public void GameOver()
    {
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }
        else
        {
            Debug.LogError("Game Over UI is not assigned!");
        }
    }
}
