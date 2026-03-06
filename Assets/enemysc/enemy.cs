using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float sayac;
    public float speed;
    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        sayac += Time.deltaTime;
        
        if (sayac % 1 == 0)
        {
            sayac = 0;
            Debug.Log("1 saniye");
            Debug.Log("Player pozisyonu: " + player.transform.position);
        }
        hareketet();
    }

    public void hareketet()
    {   

        Vector3 hareket_yonu = player.transform.position - transform.position;

        hareket_yonu.y = 0;

        hareket_yonu = hareket_yonu.normalized;

        
        transform.position += hareket_yonu * speed * Time.deltaTime;

    }
}
