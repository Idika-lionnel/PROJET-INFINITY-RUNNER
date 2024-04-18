using UnityEngine;

public class Player : MonoBehaviour
{
    public float forwardSpeed = 1f; // Vitesse de déplacement vers l'avant
    public float horizontalSpeed = 1f; // Vitesse de déplacement horizontal
    public float leftLimit = -2.1f; // Limite à gauche
    public float rightLimit = 2.1f; // Limite à droite
    public float middlePosition = 0f; // Position du milieu

    private Camera mainCamera;
    private Vector3 cameraOffset;
    private bool moveLeft = false;
    private bool moveRight = false;

    void Start()
    {
        mainCamera = Camera.main;
        cameraOffset = mainCamera.transform.position - transform.position;
    }

    void Update()
    {
        // Mouvement automatique vers l'avant
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // Gestion du mouvement horizontal
        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x != leftLimit)
        {
            moveLeft = true;
            moveRight = false;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x != rightLimit)
        {
            moveRight = true;
            moveLeft = false;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            moveLeft = false;
            moveRight = false;
        }

        // Déplacement horizontal
        if (moveLeft)
        {
            float newXPosition = Mathf.MoveTowards(transform.position.x, leftLimit, horizontalSpeed * Time.deltaTime);
            transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);
        }
        else if (moveRight)
        {
            float newXPosition = Mathf.MoveTowards(transform.position.x, rightLimit, horizontalSpeed * Time.deltaTime);
            transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);
        }

        // Retour au milieu si le joueur est au-delà des limites
        if (transform.position.x < leftLimit || transform.position.x > rightLimit)
        {
            float newXPosition = Mathf.MoveTowards(transform.position.x, middlePosition, horizontalSpeed * Time.deltaTime);
            transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);
        }

        // Suivre le joueur avec la caméra
        if (mainCamera != null)
        {
            mainCamera.transform.position = transform.position + cameraOffset;
        }
    }
}
