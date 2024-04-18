using UnityEngine;

public class Test : MonoBehaviour
{
    public Scoring score;
    private float timer = 0f; // Compteur de temps

    // Start is called before the first frame update
    void Start()
    {
        // Initialiser ce qui est nécessaire dans la méthode Start
    }

    // Update is called once per frame
    void Update()
    {
        // Incrémenter le compteur de temps
        timer += Time.deltaTime;

        // Vérifier si une seconde s'est écoulée
        if (timer >= 1f)
        {
            // Réinitialiser le compteur de temps
            timer = 0f;

            // Ajouter 1 au score
            score.AddScore(10);
        }
    }
}
