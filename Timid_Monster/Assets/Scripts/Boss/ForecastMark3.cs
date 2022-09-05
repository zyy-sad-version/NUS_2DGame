using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForecastMark3 : MonoBehaviour
{
    private float spawnTime = 0.5f;        // The amount of time between each spawn.
    private float spawnDelay = 0.5f;        // The amount of time before spawning starts.
    private bool flickering = true;
    static private Bullet bullet;
    public int flickerCount = 0;
    static private Boss3 boss = null;
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("Boss3").GetComponent<Boss3>();
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }

    // Update is called once per frame
    void Spawn()
    {
        //Debug.Log("----flicker count" + flickerCount);
        if(flickering){
            flickerCount ++;
            transform.gameObject.SetActive(false);
            flickering = !flickering;
        }
        else if(!flickering){
            transform.gameObject.SetActive(true);
            flickering = !flickering;
        }   
        
        if(flickerCount >= 1){
            boss.LaunchAttackStyleThree();
            Destroy(transform.gameObject);
            CancelInvoke();
        }
    }
}
