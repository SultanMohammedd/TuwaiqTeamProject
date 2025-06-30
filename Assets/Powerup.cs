using UnityEngine;

public class Powerup : MonoBehaviour
{
    public PowerupEffect powerupEffect;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PlayerAgro"))
        {
            powerupEffect.Apply(other.gameObject);
            Destroy(gameObject);
            
        }
    }
}
