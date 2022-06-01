using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class buttonappear : MonoBehaviour
{
   
    [SerializeField] Transform toComeFromObj;
    Vector2 startpos;
    private void Start()
    {
        startpos = transform.position;
    }
    private void Update()
    {
        transform.position = Vector2.Lerp(transform.position,toComeFromObj.position,0.1f);
    }

    private void OnDisable()
    {
        transform.position = startpos;
    }
}
