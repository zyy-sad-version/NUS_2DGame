using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BountifulBullet : MonoBehaviour
{
    private float speed = 30f;
    private float RotateSpeed = 0.03f;
    private Vector3 timmyLocation;
    private Vector3 target;
    private float spawnTime = 0.5f;        // The amount of time between each spawn.
    private float spawnDelay = 0.1f;   
    private bool flickering = true;
    public int flickerCount = 0;

    void Start(){
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
        Destroy(gameObject, 7f);
    }

    void Update(){
        Boss3 boss = GameObject.Find("Boss3").GetComponent<Boss3>();
        if(boss.blood <= 0){
            CancelInvoke();
            Destroy(gameObject);
        }
    }

    void Spawn(){
        if(flickering){
            for(int i = 1; i <= 4; i++){
                GameObject e = Instantiate(Resources.Load("Prefabs/Bullet") as GameObject); // Prefab MUST BE locaed in Resources/Prefabs folder!
                e.GetComponent<Bullet>().boss = GameObject.Find("Boss3").GetComponent<Boss3>().gameObject;
                e.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0F) ;
                e.transform.up = transform.up;
                switch(i){
                    case 1:
                        e.transform.Rotate(0, 0, 0);
                        break;
                    case 2:
                        e.transform.Rotate(0, 0, -90);
                        break;
                    case 3:
                        e.transform.Rotate(0, 0, 90);
                        break;
                    case 4:
                        e.transform.Rotate(0, 0, -180);
                        break;
                }
            }
            flickering = false;
        }
        else{
          flickering = true;
        }
    }
}
