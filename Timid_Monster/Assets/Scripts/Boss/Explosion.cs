using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float spawnTime = 0.5f;        // The amount of time between each spawn.
    private float spawnDelay = 0.5f;        // The amount of time before spawning starts.
    public int flickerCount = 0;
    public bool hitflag = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }

    // Update is called once per frame
    void Spawn()
    {
        flickerCount ++;
        if(flickerCount < 4){
            CameraSupport s = Camera.main.GetComponent<CameraSupport>();
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            Color c = sr.color;
            const float delta = 0.8f;
            c.r *= delta;
            c.g *= delta;
            c.b *= delta;
            c.a *= delta;
            sr.color = c;
        }
        else{
            Destroy(gameObject);
            CancelInvoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Timmy" && !hitflag){
            Debug.Log("hit timmy");
            hitflag = true;
            Destroy(transform.gameObject);  // kills self
        }
    }
}
