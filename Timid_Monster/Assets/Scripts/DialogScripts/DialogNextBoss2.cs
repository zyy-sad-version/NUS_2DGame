using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogNextBoss2 : MonoBehaviour
{
    public BossDialog2 dialog;
    // Start is called before the first frame update
    void Start()
    {
    this.GetComponent<Button>().onClick.AddListener(OnClick);
 
    }

    // Update is called once per frame
    void OnClick()
    {
        dialog.dialogPocess++;
    }
}
