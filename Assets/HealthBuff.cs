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
        if (taragt.GetComponent<NewMonoBehaviourScript>().playerHealth == 3)
        {
            taragt.GetComponent<NewMonoBehaviourScript>().Heart3.SetActive(true);
            taragt.GetComponent<NewMonoBehaviourScript>().Heart2.SetActive(true);
            taragt.GetComponent<NewMonoBehaviourScript>().Heart1.SetActive(true);
        }
        if (taragt.GetComponent<NewMonoBehaviourScript>().playerHealth == 2)
        {
            taragt.GetComponent<NewMonoBehaviourScript>().Heart3.SetActive(false);
            taragt.GetComponent<NewMonoBehaviourScript>().Heart2.SetActive(true);
            taragt.GetComponent<NewMonoBehaviourScript>().Heart1.SetActive(true);
        }
        if (taragt.GetComponent<NewMonoBehaviourScript>().playerHealth == 1)
        {
            taragt.GetComponent<NewMonoBehaviourScript>().Heart2.SetActive(false);
            taragt.GetComponent<NewMonoBehaviourScript>().Heart1.SetActive(true);
        }
        if (taragt.GetComponent<NewMonoBehaviourScript>().playerHealth == 0)
        {
            taragt.GetComponent<NewMonoBehaviourScript>().Heart1.SetActive(false);

        }
    }
}
