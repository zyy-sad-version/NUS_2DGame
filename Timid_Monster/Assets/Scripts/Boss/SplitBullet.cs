using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitBullet : MonoBehaviour
{
    private float speed = 5f;
    private TimmyInBoss timmy;
    private float kVeryClose = 3f;
    public const float RotateSpeed = 0.03f;
    private float spawnTime = 2f;
    private float spawnDelay = 2f;

    void Start()
    {
        timmy = GameObject.Find("Timmy").GetComponent<TimmyInBoss>();
        transform.up = new Vector3(timmy.transform.position.x, timmy.transform.position.y, -3F);
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
        Debug.Log("Timmy position: " +  timmy.transform.position);
        Destroy(gameObject, 8f);
    }

    void Update()
    {
        transform.position += transform.up * (speed * Time.smoothDeltaTime);
        Debug.Log("Towa: " + transform.up);
        CameraSupport s = Camera.main.GetComponent<CameraSupport>(); 
        if (s != null) 
        {
            Bounds myBound = GetComponent<Renderer>().bounds; 
            CameraSupport.WorldBoundStatus status = s.CollideWorldBound(myBound);
            if (status != CameraSupport.WorldBoundStatus.Inside){
                Destroy(transform.gameObject);
            }
        }
        Boss2 boss = GameObject.Find("Boss2").GetComponent<Boss2>();
        if(boss.blood <= 0){
            Destroy(transform.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Timmy"){
            Destroy(transform.gameObject);
        }
    }

    private void Spawn(){
        for(int i = 1; i <= 8 ; i++){
            GameObject e = Instantiate(Resources.Load("Prefabs/Bullet") as GameObject); // Prefab MUST BE locaed in Resources/Prefabs folder!
            e.GetComponent<Bullet>().boss = GameObject.Find("Boss2").GetComponent<Boss2>().gameObject;
            e.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0F) ;
            e.transform.up = transform.up;
            switch(i){
                case 1:
                    e.transform.Rotate(0, 0, 90);
                    break;
                case 2:
                    e.transform.Rotate(0, 0, -45);
                    break;
                case 3:
                    e.transform.Rotate(0, 0, 45);
                    break;
                case 4:
                    e.transform.Rotate(0, 0, -90);
                    break;
                case 5:
                    e.transform.Rotate(0, 0, 90);
                    break;
                case 6:
                    e.transform.Rotate(0, 0, -135);
                    break;
                case 7:
                    e.transform.Rotate(0, 0, 135);
                    break;
                case 8:
                    e.transform.Rotate(0, 0, -180);
                    break;
            }
        }
    }
}
