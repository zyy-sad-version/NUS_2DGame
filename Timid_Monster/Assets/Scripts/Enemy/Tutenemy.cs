using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutenemy : MonoBehaviour
{
    private const float speed = 20f;
    private int towards = 1;
    private const float RotateSpeed = 0.03f;
    private GameObject mTarget = null;
    private const float kVeryClose = 1f;
    private bool routeReverse = false;
    public SpriteRenderer sr;
    public Sprite[] pic;

    // Start is called before the first frame update
    void Start()
    {
        towards = 2;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(towards == 1){
            mTarget = GameObject.Find("A");
        }
        if(towards == 2){
            mTarget = GameObject.Find("B");
        }
        if(towards == 3){
            mTarget = GameObject.Find("C");
        }
        if(towards == 4){
            mTarget = GameObject.Find("D");
        }
         Vector3 dir = new Vector3(mTarget.transform.position.x, mTarget.transform.position.y, -0.1F);
         transform.localPosition = Vector3.MoveTowards(transform.localPosition, dir, speed * Time.deltaTime);
         float dist = Vector3.Distance(dir, transform.localPosition);
         if(dist < kVeryClose){
            ComputeNewTargetPosition();
            //0: up; 1: left; 2: right; 3: down;
            if(towards == 2 && !routeReverse){
                //transform.up = new Vector3(0, 1, 0);
                sr.sprite = pic[0];
            }
            if(towards == 3 && !routeReverse){
                //transform.up = new Vector3(-1, 0, 0);
                sr.sprite = pic[1];
            }
            if(towards == 4 && !routeReverse){
               // transform.up = new Vector3(0, -1, 0);
                sr.sprite = pic[3];
            }
            if(towards == 3 && routeReverse){
              //  transform.up = new Vector3(0, 1, 0);
                sr.sprite = pic[0];
            }
            if(towards == 2 && routeReverse){
             //   transform.up = new Vector3(1, 0, 0);
                sr.sprite = pic[2];
            }
            if(towards == 1 && routeReverse){
              //  transform.up = new Vector3(0, -1, 0);
                sr.sprite = pic[3];
            }
         }
    }

    private void ComputeNewTargetPosition()
    {
        if(routeReverse){
            towards = towards - 1;
            if(towards == 0){
                towards = 2;
                routeReverse = !routeReverse;
            }
        }
        else{
            towards = towards + 1;
            if(towards == 5){
                towards = 3;
                routeReverse = !routeReverse;
            }
        }
    }

    private void CheckTargetPosition()
    {
        // Access the GameManager
        float dist = Vector3.Distance(mTarget.transform.localPosition, transform.localPosition);
        //if (dist < kVeryClose)
            //ComputeNewTargetPosition();
    }

}
