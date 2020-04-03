using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballscript : MonoBehaviour
{
    public int speed = 10;
    // Start is called before the first frame update
    public Rigidbody2D ball;
    public Animator animatr;
    void Start()
    {
        ball.velocity = new Vector2(1, 1) * speed;
        animatr.SetBool("IsMove", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ball.velocity.x > 0) //move right
        {
            ball.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);   
        }
        else
        {
            ball.GetComponent<Transform>().localScale = new Vector3(-1, 1, 1);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.name=="tembokR" || other.collider.name=="tembokL")
        {
            StartCoroutine(jeda());
        }

        IEnumerator jeda()
        {
            ball.velocity = new Vector2(0, 0);
            animatr.SetBool("IsMove", false);
            ball.GetComponent<Transform>().position = new Vector2(0, 0);
            yield return new WaitForSeconds(1);
            ball.velocity = new Vector2(1, 1) * speed;
            animatr.SetBool("IsMove", true);
        }
    }
}
