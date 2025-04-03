using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathZone : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float deathOffset = -2f; // How far behind the camera the player can fall before dying

    void Update()
    {
        if (transform.position.x < cameraTransform.position.x + deathOffset)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player died!");
        // You can replace this with your actual game over logic
    }
}
