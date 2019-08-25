using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int life = 3;

    private int points = 0;

    public Image[] iconsLife;
    public TextMeshProUGUI textPoints;
    public GameObject paddle;
    public GameObject ball;
    public GameObject prefabStar;
    // Start is called before the first frame update
    void Start()
    {
        updateLifeUI();
        InvokeRepeating("spawnItem", 3, 8);        
    }

    protected void spawnItem() {
        GameObject item = Instantiate(prefabStar);
        item.transform.position = new Vector2(UnityEngine.Random.Range(-7.44f, 7.44f), 4.12f);
    }

    protected void restartGame() {
        ball.GetComponent<ArkanoidBallBehaviour>().stopMovement();
        ball.GetComponent<ArkanoidBallBehaviour>().restartPosition();
        Invoke("initGame", 2);
    }

    protected void initGame() {
        ball.GetComponent<ArkanoidBallBehaviour>().initMovement();
    }

    public void onItemCollision(GameObject other) {
        Vector2 size = paddle.GetComponent<SpriteRenderer>().size;
        size.x += 2;

        paddle.GetComponent<SpriteRenderer>().size = size;
        paddle.GetComponent<CapsuleCollider2D>().size = size;

        Destroy(other);
    }

    public void decreaseLife() {
        life -= 1;
        updateLifeUI();
        if (life <= 0)
            SceneManager.LoadScene("Scenes/GameOver");
        else 
            Invoke("restartGame", 2);
    }

    public void increasePoints(int points) {
        this.points += points;
        updateTextPoint();
    }

    private void updateLifeUI() {
        int index = 0;
        foreach (Image icon in iconsLife) {
            icon.gameObject.SetActive(false);
            if (index < life)
                icon.gameObject.SetActive(true);
            index++;
        }
    }

    private void updateTextPoint() {
        textPoints.text = maskPoints(this.points);
    }

    private string maskPoints(double points) {
        int count = 5;
        while ((points /= 10.0) >= 1)
            count--;
        string value = "";
        do {
            value += "0";
            count--;
        } while (count > 0);
        value += this.points.ToString();
        return value;
    }

}
