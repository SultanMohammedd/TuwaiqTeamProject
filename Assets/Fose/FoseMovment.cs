using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class FoseMovment : MonoBehaviour
{
    public float FoseSpeed;
    public NavMeshAgent EnemyAgent;
    public Transform PlayerPose;
    public Vector3 EnemyAgro;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnemyAgro = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position -= new Vector3(0, 0, FoseSpeed);
        EnemyAgent.SetDestination(EnemyAgro);
    }


    
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PlayerAgro")
        {

            EnemyAgro = other.transform.position;
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerAgro"))
        {
            EnemyAgro = transform.position;
        }
    }
   

}


