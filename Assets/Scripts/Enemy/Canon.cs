using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] private GameObject Spawnpoint;
    [SerializeField] private GameObject Bulletprefab;
    [SerializeField] private float Speed = 10;
    [SerializeField] private float ShootIntervelMin;
    [SerializeField] private float ShootIntervalMax;
    
    IEnumerator Start()
    {
        GameObject spawn = Instantiate(Bulletprefab) as GameObject;
        spawn.transform.position = Spawnpoint.transform.position;
        spawn.GetComponent<Rigidbody2D>().velocity = Spawnpoint.transform.right * Speed;
        Destroy(spawn, 3);
        // størrelse
        //spawn.transform.localScale *= Random.Range(1, 3);
        yield return new WaitForSeconds(Random.Range(ShootIntervelMin, ShootIntervalMax));

        StartCoroutine(Start());


    }
   
}
