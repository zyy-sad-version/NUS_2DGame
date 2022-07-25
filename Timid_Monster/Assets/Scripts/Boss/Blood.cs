using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    private float width;
    private float height;
    private RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        width =rectTransform.rect.width;
        height = rectTransform.rect.height;
    }

    // Update is called once per frame
    void Update()
    {
        //loseHealth();
    }
    public void loseHealth(float total, float damage, float oriHealth)
    {
        

        float temp = width*((oriHealth-damage)/total);
        rectTransform.sizeDelta = new Vector2(temp,height);
    }
}
