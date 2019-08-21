using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject paddle;
    public GameObject prefabStar;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnItem", 3, 8);        
    }

    protected void spawnItem() {
        GameObject item = Instantiate(prefabStar);
        item.transform.position = new Vector2(UnityEngine.Random.Range(-7.44f, 7.44f), 4.12f);
    }

    public void onItemCollision(GameObject other) {
        Vector2 size = paddle.GetComponent<SpriteRenderer>().size;
        size.x += 2;

        paddle.GetComponent<SpriteRenderer>().size = size;
        paddle.GetComponent<CapsuleCollider2D>().size = size;

        Destroy(other);
    }
}
