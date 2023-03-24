using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int cash = 0;
    public static int cashGen = 0;

    private void Start()
    {
        InvokeRepeating("Cashgen", 0f, 15f);
    }

    private void Cashgen()
    {
        cash += cashGen;
    }


}
