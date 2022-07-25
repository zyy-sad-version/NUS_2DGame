using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    // Start is called before the first frame update
    public Boss1 center = null;
    private float rotateSpeed = 50f;
    private Vector3 dir;
    private float dis;
    private float startPosy;
    private float centerx;
    private float centery;

    void Start()
    {
        center = GameObject.Find("Boss1").GetComponent<Boss1>();
        dis = Vector3.Distance(transform.position, center.transform.position);
        dir = transform.position - center.transform.position;
        centerx = center.transform.position.x;
        centery = center.transform.position.y;
        Destroy(gameObject, 3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(center.blood>0){
            transform.position = center.transform.position + dir.normalized * dis;
            transform.RotateAround(center.transform.position, Vector3.forward, rotateSpeed * Time.deltaTime);
            dir = transform.position - center.transform.position;
            startPosy = transform.position.y;
        }
        else{
            Destroy(gameObject);
        }
        
    }
}
