using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class NormalNextBtn3 : MonoBehaviour
{
    public NormalDialog3 dialog;
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
