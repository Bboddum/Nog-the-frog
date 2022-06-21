using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Itemcollector : MonoBehaviour
{
    [SerializeField] private Text Pointtext;
    [SerializeField] private Text Lifetext;

    private void Start()
    {
        Pointtext.text = "Point: " + Lifeamount.Point;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            Lifeamount.Point++;
            Destroy(collision.gameObject);
            Pointtext.text = "Point: " + Lifeamount.Point;
        }
        if (collision.gameObject.CompareTag("Apple"))
        {
            Lifeamount.Point += 2;
            Destroy(collision.gameObject);
            Pointtext.text = "Point: " + Lifeamount.Point;
        }
        if (collision.gameObject.CompareTag("Extra"))
        {
            Lifeamount.Life ++;
            Destroy(collision.gameObject);
            Lifetext.text = "x " + Lifeamount.Life;
        }
    }
}
