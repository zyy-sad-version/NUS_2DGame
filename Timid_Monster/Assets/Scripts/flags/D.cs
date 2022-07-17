using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D : MonoBehaviour
{
    public float Dposx = 0f;
    public float Dposy = 0f;
    public float Dposz = -0.1f;

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
