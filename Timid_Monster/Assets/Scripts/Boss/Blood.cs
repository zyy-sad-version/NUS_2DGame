using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //loseHealth();
    }
    public void loseHealth(float total, float damage, float oriHealth)
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        float width =rectTransform.rect.width;
        float height = rectTransform .rect.height;

        float temp = width*(oriHealth-damage)/total;
        rectTransform.sizeDelta = new Vector2(temp,height);
    }
}
