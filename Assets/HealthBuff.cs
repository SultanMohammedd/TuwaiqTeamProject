using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/HealthBuff")]
public class HealthBuff : PowerupEffect
{
    public float healAmount;
    public override void Apply(GameObject taragt)
    {
        taragt.GetComponent<NewMonoBehaviourScript>().playerHealth += healAmount;

        if (taragt.GetComponent<NewMonoBehaviourScript>().playerHealth > 
            taragt.GetComponent<NewMonoBehaviourScript>().maxHealth)
        {
            taragt.GetComponent<NewMonoBehaviourScript>().playerHealth =
                taragt.GetComponent<NewMonoBehaviourScript>().maxHealth;
        }
    }
}
