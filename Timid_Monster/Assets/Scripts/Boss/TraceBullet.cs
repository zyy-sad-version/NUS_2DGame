using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceBullet : MonoBehaviour
{
    private float spawnTime = 0.5f;        // The amount of time between each spawn.
    private float spawnDelay = 0.5f;        // The amount of time before spawning starts.
    static private Bullet bullet;
    static private TimmyInBoss timmy = null;
    static private Boss3 boss = null;
    public const float RotateSpeed = 0.03f;
    public const float kVeryClose = 3f;
    public const float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        timmy = GameObject.Find("Timmy").GetComponent<TimmyInBoss>();
        boss = GameObject.Find("Boss3").GetComponent<Boss3>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = new Vector3(timmy.transform.position.x, timmy.transform.position.y, -0.1F);
        PointAtPosition(dir, RotateSpeed * Time.smoothDeltaTime);
        transform.localPosition += speed * Time.smoothDeltaTime * transform.up;
        if(boss.blood <= 0){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Timmy"){
            Debug.Log("hit timmy");
            Destroy(transform.gameObject);  // kills self
        }
    }

    private void PointAtPosition(Vector3 p, float r)
    {
        Vector3 v = p - transform.localPosition;
        transform.up = Vector3.LerpUnclamped(transform.up, v, r);
    }
}
