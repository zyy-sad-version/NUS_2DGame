using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    // Start is called before the first frame update
    public Boss1 center = null;
    private float rotateSpeed = 30f;
    private Vector3 dir;
    private float dis;
    private float startPosy;


    void Start()
    {
        center = GameObject.Find("Boss1").GetComponent<Boss1>();
        dis = Vector3.Distance(transform.position, center.transform.position);
        dir = transform.position - center.transform.position;
        startPosy = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(center.blood>0){
            transform.position = center.transform.position + dir.normalized * dis;
            transform.RotateAround(center.transform.position, Vector3.forward, rotateSpeed * Time.deltaTime);
            dir = transform.position - center.transform.position;
            if(startPosy > 0 && transform.position.x > 0){
                Destroy(transform.gameObject);
            }
            if(startPosy < 0 && transform.position.x < 0){
                Destroy(transform.gameObject);
            }
        }
        else{
            Destroy(gameObject);
        }
        
    }
}
