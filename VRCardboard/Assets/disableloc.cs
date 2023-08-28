using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class disableloc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cam = gameObject.transform.Find("Main Camera").GetComponent<Transform>().position;
        transform.position = -cam;
    }
}
