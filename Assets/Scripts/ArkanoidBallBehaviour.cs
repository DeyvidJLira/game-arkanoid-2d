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
        if (collision.transform.tag == "Brick")
            gameManager.increasePoints(10);
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
