using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    public Text field;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void SetState(bool isOn, string text)
    {
        transform.gameObject.SetActive(isOn);
        field.text = text;
    }
}
