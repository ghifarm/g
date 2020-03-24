using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballscript : MonoBehaviour
{
    public int speed = 10;
    // Start is called before the first frame update
    public Rigidbody2D ball;
    void Start()
    {
        ball.velocity = new Vector2(1, 1) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.name=="tembokR" || other.collider.name=="tembokL")
        {
            GetComponent<Transform>().position = new Vector2(0, 0);
        }
    }
}
