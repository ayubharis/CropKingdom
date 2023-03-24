using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Money : MonoBehaviour
{
    public TextMeshProUGUI moneyText; // reference to the Text component of the textbox

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "$" + Player.cash.ToString();
    }
}
