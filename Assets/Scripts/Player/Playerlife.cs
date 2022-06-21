using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Playerlife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;   

    public Text Lifetext;

    private Vector3 RespawnPoint;
    public GameObject Falldetector;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        RespawnPoint = transform.position;
        Lifetext.text = "x " + Lifeamount.Life;
    }

    private void Update()
    {
        Falldetector.transform.position = new Vector2(transform.position.x, Falldetector.transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Falldetector"))
        {
            Die();
        }
        else if (collision.tag == "Checkpoint")
        {
            RespawnPoint = transform.position;
        }

    }

    private void Die()
    {
        
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Deadtrigger");
        Lifeamount.Life--;
        PlayerCheck();
        Invoke("wait", .9f);
    }
    private void PlayerCheck()
    {
        {
            if (Lifeamount.Life < 0)
            {
                Lifeamount.Life = 3;
                Lifeamount.Point = 0;
                SceneManager.LoadScene("Game_over");
            }
            else
            {
                Lifetext.text = "x " + Lifeamount.Life;
            }
        }
    }
    void wait()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        transform.position = RespawnPoint;
    }

}
