using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    private bool crashed;

    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private GameOverManager gameOverManager;


    void OnCollisionEnter(Collision collsion) 
    {
        if (crashed)
            return;

        if(collsion.gameObject.CompareTag("Obstacle"))
        {
            crashed = true;

            Debug.Log("Crashed!");

            // Stoppingg car movement
            Rigidbody rb = GetComponent<Rigidbody>();

            if (rb) 
            {
                rb.linearVelocity = Vector3.zero;

                scoreManager.SaveHighScore();

                gameOverManager.GameOver(scoreManager.GetScore());
            }
        }
    }
}
