using UnityEngine;
using TMPro; // Import the TextMeshPro namespace

public class Scoring : MonoBehaviour
{
    public TMP_Text ScoreText; // Use TMP_Text instead of Text
    public int score = 0;
    public int maxScore;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore();
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // You can add any additional update logic here if needed
    }
}
