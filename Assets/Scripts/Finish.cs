using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public GameObject Player;
    public int NextLevel;
    public float TimeUntilNextLevel;
    [SerializeField] private AudioSource Nextlevelsound;

        private void OnTriggerEnter2D(Collider2D collision)
        {

        if (collision.tag == ("Player"))
        {
            Player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            Nextlevelsound.Play();
            StartCoroutine(Waitandchangelevel());

        }
    }
    IEnumerator Waitandchangelevel()
    {
        yield return new WaitForSeconds(TimeUntilNextLevel);
        SceneManager.LoadScene(NextLevel);
    }
}
