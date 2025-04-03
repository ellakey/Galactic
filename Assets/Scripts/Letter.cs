using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{
    public char letterChar;
    public bool isGood = true; // green = true, red = false

    private void Update()
    {
        transform.Translate(Vector2.down * 2f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
    Debug.Log($"Triggered by {other.name}");

        if (other.CompareTag("Player"))
        {
            Debug.Log(isGood ? $"Collected letter: {letterChar}" : "Hit by red letter!");

            if (isGood)
            {
                other.GetComponent<PlayerLetterCollector>().CollectLetter(letterChar);
            }
            else
            {
                other.GetComponent<PlayerHealth>().TakeDamage();
            }

            Destroy(gameObject);
        }
    }
}
