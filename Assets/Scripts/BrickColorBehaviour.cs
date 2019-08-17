using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickColorBehaviour : MonoBehaviour
{
    public Color[] damageColor;
    int maxHits;
    protected int hitNumbers;

    // Start is called before the first frame update
    void Start()
    {
        hitNumbers = 0;
        maxHits = damageColor.Length;
    }

    private void OnCollisionExit2D(Collision2D collision) {
        GetComponent<SpriteRenderer>().color = damageColor[hitNumbers];

        hitNumbers++;

        if (hitNumbers >= maxHits)
            Destroy(gameObject);
    }
}
