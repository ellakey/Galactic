using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform followTransform = null;
    [SerializeField] private bool lockY = false;
    [SerializeField] private float lockYPosMin = 0f;
    [SerializeField] private float lockYPosMax = 0f;
    [SerializeField] private Transform backgroundTransform = null;
    [SerializeField] private Transform middlegroundTransform = null;

    //parallax variables 
    [SerializeField] [Range(0f, 1f)] private float moveScaleFactor = 1f;
    [SerializeField] private bool verticalParalax = true;

    //Scrool
    [SerializeField] private float scrollSpeed = 2f;
    
    private void Awake()
    {
        if(followTransform == null)
            Debug.LogException(new System.NullReferenceException("Follow Trasnform not assigned."));
        if(backgroundTransform == null)
            Debug.LogException(new System.NullReferenceException("Background Trasnform not assigned."));
        if(middlegroundTransform == null)
            Debug.LogException(new System.NullReferenceException("middleground Trasnform not assigned."));
    }
    
    void Start()
    {
        
    }

 
    void Update()
    {
        //Camera Movement 
        transform.position += new Vector3(scrollSpeed * Time.deltaTime, 0, 0);

        //background movement 
        backgroundTransform.position = new Vector3(transform.position.x, transform.position.y, backgroundTransform.position.z);

        //middleground movement 
        middlegroundTransform.position = new Vector3(transform.position.x * moveScaleFactor, verticalParalax == true ? transform.position.y * moveScaleFactor : middlegroundTransform.position.y, backgroundTransform.position.z);
    }
}
