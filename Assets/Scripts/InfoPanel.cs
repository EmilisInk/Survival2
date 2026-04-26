using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    private TextMeshProUGUI[] textBoxes;

    public static InfoPanel instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Debug.LogWarning("More than one InfoPanel in scene.");
    }

    private void Start()
    {
        textBoxes = GetComponentsInChildren<TextMeshProUGUI>();
        
        foreach(TextMeshProUGUI text in textBoxes)
        {
            text.text = "";
        }
    }

    public void ShowInfo(string infoText)
    {
        foreach(var t in textBoxes)
        {
            if(t.text == "")
            {
                t.text = infoText;
                t.transform.SetSiblingIndex(transform.childCount - 1);

                Invoke(nameof(Clear), 3f);
                return;
            }
        }
    }

    public void Clear()
    {
        foreach(var t in textBoxes)
        {
            t.text = "";
        }
    }
}
