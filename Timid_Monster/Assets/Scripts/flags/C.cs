using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C : MonoBehaviour
{
    public float Cposx = -85f;
    public float Cposy = 55f;
    public float Cposz = -0.1f;

    // Start is called before the first frame update
    public bool hide = true;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = transform.localPosition;
        p.z = -11f;
        transform.localPosition = p;
    }

    
}
