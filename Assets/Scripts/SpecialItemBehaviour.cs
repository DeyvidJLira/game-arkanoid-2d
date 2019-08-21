using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialItemBehaviour : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "GameOver")
            Destroy(gameObject, 1f);
    }

}
