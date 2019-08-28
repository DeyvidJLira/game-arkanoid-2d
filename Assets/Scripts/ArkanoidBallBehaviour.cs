using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArkanoidBallBehaviour : MonoBehaviour
{
    public float startSpeed = 10f;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = (Vector2.up + Vector2.right) * startSpeed; 
    }
    
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "Brick") {
            gameManager.increasePoints(10);
            GetComponent<Rigidbody2D>().velocity *= -1;
            Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
            if (transform.position.y < collision.transform.position.y) {
                velocity.y = -1 * startSpeed;
            } else {
                velocity.y = startSpeed;
            }
            GetComponent<Rigidbody2D>().velocity = velocity;
        }
        if (collision.transform.tag == "Paddle") {
            Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
            velocity.y = startSpeed;
            if (transform.position.x < collision.transform.position.x)
                velocity.x = -1 * startSpeed;
            else
                velocity.x = startSpeed;
            GetComponent<Rigidbody2D>().velocity = velocity;
        }
        if (collision.transform.tag == "Wall") {
            Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
            if (transform.position.x < collision.transform.position.x)
                velocity.x = -1 * startSpeed;
            else
                velocity.x = startSpeed;
            GetComponent<Rigidbody2D>().velocity = velocity;
        }
        if (collision.transform.tag == "Ceiling") {
            Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
            velocity.y = -1 * startSpeed;
            GetComponent<Rigidbody2D>().velocity = velocity;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.transform.tag == "GameOver") {
            gameManager.decreaseLife();            
        }
    }

    public void restartPosition() {
        transform.position = Vector2.zero;
    }

    public void initMovement() {
        GetComponent<Rigidbody2D>().velocity = (Vector2.up + Vector2.right) * startSpeed;
    }

    public void stopMovement() {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

}
