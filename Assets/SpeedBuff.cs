using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CreateAssetMenu(menuName = "Powerups/SpeedBuff")]
public class SpeedBuff : PowerupEffect
{
    public float buffAmount;
    public float buffDuration;

    public override void Apply(GameObject target)
    {
        // Get the NewMonoBehaviourScript component from the target
        NewMonoBehaviourScript playerScript = target.GetComponent<NewMonoBehaviourScript>();
        if (playerScript != null)
        {
            // Now, we tell the playerScript (which is a MonoBehaviour) to start the coroutine.
            // We pass this ScriptableObject's properties to the coroutine.
            playerScript.StartPowerupCoroutine(SpeedBuffRoutine(playerScript,target));
        }
        else
        {
            Debug.LogError("SpeedBuff: Target does not have a NewMonoBehaviourScript component!", target);
        }


    }

    private IEnumerator SpeedBuffRoutine(NewMonoBehaviourScript playerScript, GameObject target)
    {
        float oldSpeed = playerScript.playerSpeed; // Store the original speed
        
        playerScript.playerSpeed = buffAmount; // Apply the buff
        Debug.Log($"Speed buff applied! New speed: {playerScript.playerSpeed}");
        
        yield return new WaitForSeconds(buffDuration); // Wait for the duration
        
        playerScript.playerSpeed = oldSpeed; // Revert to original speed
        Debug.Log($"Speed buff ended! Speed reverted to: {playerScript.playerSpeed}");
    }
}
