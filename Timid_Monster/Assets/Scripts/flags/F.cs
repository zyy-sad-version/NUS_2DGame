using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F : MonoBehaviour
{
    public float Aposx = -85f;
    public float Aposy = 55f;
    public float Aposz = -0.1f;

    // Start is called before the first frame update
    public bool hide = true;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = transform.localPosition;
        p.z = 1f;
        transform.localPosition = p;
    }

    
}
