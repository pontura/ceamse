using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummaryNum : MonoBehaviour
{
    public Text field;

   public void Init(int total)
    {
        if(total == 0)
        {
            this.gameObject.SetActive(false);
            return;
        }
        else
        {
            this.gameObject.SetActive(true);
            field.text = total.ToString();
        }
    }
}
