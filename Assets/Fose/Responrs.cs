using UnityEngine;

public class Responrs : MonoBehaviour
{

    public GameObject EnemyPrefap;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnEnemys",0,0.50f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void SpawnEnemys()
    {
       Debug.Log("Enemy SpawnEnemys");

       float PoseRangX = transform.position.x;
       PoseRangX -= Random.Range(-100f, 100f);
           Vector3 SpawnPoint = new Vector3(PoseRangX,transform.position.y,transform.position.z);
       
           Instantiate(EnemyPrefap,
           SpawnPoint,
               transform.rotation,
                   transform) ;
    }
}

