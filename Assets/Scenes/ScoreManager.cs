using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour {
    public TextMeshProUGUI score; // Champ de texte affichant le score
    public static int scoreValue = 0; // Variable pour stocker la valeur du score

    // Use this for initialization
    void Start() {
        // Réinitialise le score au démarrage du jeu
        ResetScore();
    }

    // Méthode pour réinitialiser le score
    public void ResetScore() {
        // Réinitialise la valeur du score à zéro
        scoreValue = 0;
        // Met à jour le texte du score pour refléter la nouvelle valeur
        UpdateScoreText();
    }

    // Méthode pour mettre à jour le texte du score
    public void UpdateScoreText() {
        // Met à jour le texte du score avec la nouvelle valeur
        score.text = "Score: " + scoreValue;
    }

    // Méthode pour incrémenter le score de 10 points
    public void IncrementScore() {
        // Incrémente la valeur du score de 10
        scoreValue += 10;
        // Met à jour le texte du score pour refléter la nouvelle valeur
        UpdateScoreText();
    }
}
