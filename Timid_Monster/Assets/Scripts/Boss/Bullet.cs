using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 40f;
    static private Boss boss = null;

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("Boss").GetComponent<Boss>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("boss eng" + boss.bulletCnt);
        transform.position += transform.up * (speed * Time.smoothDeltaTime);
        CameraSupport s = Camera.main.GetComponent<CameraSupport>();  // Try to access the CameraSupport component on the MainCamera
        if (s != null)   // if main camera does not have the script, this will be null
        {
            // intersect my bond with the bounds of the world
            Bounds myBound = GetComponent<Renderer>().bounds;  // this is the bound on the SpriteRenderer
            CameraSupport.WorldBoundStatus status = s.CollideWorldBound(myBound);

            if (status != CameraSupport.WorldBoundStatus.Inside){
                //get boss
                //GameObject.Find("Boss").GetComponent<Boss>().bulletCnt --;
                boss.DestroyBullet();
                Destroy(transform.gameObject);  // kills self
                //Debug.Log("bullet cnt: " + GameObject.Find("Boss").GetComponent<Boss>().bulletCnt);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "TimmyBoss"){
            Debug.Log("hit timmy");
            Destroy(transform.gameObject);  // kills self
        }
    }
}
