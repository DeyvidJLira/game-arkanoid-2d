using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehaviour : MonoBehaviour {

    public GameManager gameManager;
    private string _specialItemEffect = "None";

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Star" && _specialItemEffect != "Star") {
            _specialItemEffect = collision.tag;
            gameManager.onItemCollision(collision.gameObject);
        } else {
            Destroy(collision.gameObject);
        }
    }

}
