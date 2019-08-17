using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkanoidBallBehaviour : MonoBehaviour
{
    public float startSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = (Vector2.up + Vector2.right) * startSpeed; 
    }

}
