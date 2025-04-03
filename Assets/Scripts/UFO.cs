using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private GameObject[] letterPrefabs; // mix of green and red letter prefabs
    [SerializeField] private float dropInterval = 1.5f;

    private float dropTimer;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        dropTimer -= Time.deltaTime;
        if (dropTimer <= 0f)
        {
            DropLetter();
            dropTimer = dropInterval;
        }
    }

    void DropLetter()
    {
        int index = Random.Range(0, letterPrefabs.Length);
        Instantiate(letterPrefabs[index], transform.position, Quaternion.identity);
    }
}
