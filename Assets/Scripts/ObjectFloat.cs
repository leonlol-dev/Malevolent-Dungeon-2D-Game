using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFloat : MonoBehaviour
{
    public float degreesPerSecond = 15f;
    public float amplitude = 0.5f;
    public float frequency = 1f;

    //Store position variables
    Vector2 posOffset = new Vector2();
    Vector2 tempPos = new Vector2();

    // Start is called before the first frame update
    void Start()
    {
        posOffset = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        // Spin object on the Y axis.
        //transform.Rotate(new Vector2(0f, Time.deltaTime * degreesPerSecond));

        // Make object float up and down.
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        
        transform.position = tempPos;
    }
}
