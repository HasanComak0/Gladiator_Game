using UnityEngine;

public class enemy : MonoBehaviour
{
    
    public float speed;

    public Transform playerkonum;

    public Transform enemykonum;


    void Start()
    {
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        hareketet();
    }

    public void hareketet()
    {
        Vector3 hareket_yonu = playerkonum.position - enemykonum.position;

        hareket_yonu = hareket_yonu.normalized;

        hareket_yonu.y = 0;

        transform.position += hareket_yonu * speed * Time.deltaTime;

    }
}
