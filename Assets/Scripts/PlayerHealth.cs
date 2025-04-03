using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHearts = 3;
    private int currentHearts;

    private void Start()
    {
        currentHearts = maxHearts;
    }

    public void TakeDamage()
    {
        currentHearts--;
        Debug.Log("Ouch! Hearts left: " + currentHearts);

        if (currentHearts <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died!");
        // Add respawn or Game Over screen
    }
}
