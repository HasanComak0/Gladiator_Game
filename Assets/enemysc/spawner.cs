using UnityEngine;

public class spawner : MonoBehaviour
{
    public float sayac;
    public float aralik=5;

    public GameObject enemy;


    void Start()
    {
        
    }

    void Update()
    {
        sayac += Time.deltaTime;

        if (sayac >= 5 )
        {
            spawnla();
            sayac = 0;
        }
    }
    private void spawnla()
    {
        Instantiate(enemy,transform.position,transform.rotation);
    }
}
