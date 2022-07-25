using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 20f;
    public GameObject boss = null;

    void Start()
    {
      boss =  GameObject.FindGameObjectWithTag("Boss");
    }

    void Update()
    {
        transform.position += transform.up * (speed * Time.smoothDeltaTime);
        CameraSupport s = Camera.main.GetComponent<CameraSupport>();  
        if (s != null)   
        {
            
            Bounds myBound = GetComponent<Renderer>().bounds;  
            CameraSupport.WorldBoundStatus status = s.CollideWorldBound(myBound);

            if (status != CameraSupport.WorldBoundStatus.Inside){
                Destroy(transform.gameObject); 
            }
        }
        if(boss.name == "Boss1"){
            if(boss.GetComponent<Boss1>().blood <= 0){
                Destroy(transform.gameObject);
            }
        }
        if(boss.name == "Boss2"){
            if(boss.GetComponent<Boss2>().blood <= 0){
                Destroy(transform.gameObject);
            }
        }
        if(boss.name == "Boss3"){
            if(boss.GetComponent<Boss3>().blood <= 0){
                Destroy(transform.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Timmy"){
           // Debug.Log("hit timmy");
            Destroy(transform.gameObject);  // kills self
        }
    }
}
