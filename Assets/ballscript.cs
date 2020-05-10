using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballscript : MonoBehaviour
{
    public int speed = 10;
    // Start is called before the first frame update
    public Rigidbody2D ball;
    public GameObject masterScript;
    public Animator animatr;
    public AudioSource hitEffect;
    void Start()
    {
        int x = Random.Range(0,2)*2-1; //nilai x bisa bernilai 0/1
        int y = Random.Range(0,2)*2-1; //nilai x bisa bernilai 0/1
        int speed = Random.Range(20, 26);//nilai speed antara 20 - 25
        ball.velocity = new Vector2(-1, -1) * speed;
        ball.GetComponent<Transform>().position = Vector2.zero;
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
            masterScript.GetComponent<scoringScript>().UpdateScore(other.collider.name);
            StartCoroutine(jeda()); //untuk pindah ke tengah
        }

        if(other.collider.tag=="Player"){
            hitEffect.Play();
        }

        IEnumerator jeda()
        {
            ball.velocity = new Vector2(0, 0);//menghentikan bola
            animatr.SetBool("IsMove", false);//mengubah animasi ke api berhenti
            ball.GetComponent<Transform>().position = new Vector2(0, 0);//mengubah posisi bola

            yield return new WaitForSeconds(1);

            int x = Random.Range(0,2)*2-1; //nilai x bisa bernilai 0/1
            int y = Random.Range(0,2)*2-1; //nilai x bisa bernilai 0/1 

            ball.velocity = new Vector2(x, y) * speed;//mengatur kecepatan
            animatr.SetBool("IsMove", true);//mengubah animasi ke api bergerak
        }
    }
}
