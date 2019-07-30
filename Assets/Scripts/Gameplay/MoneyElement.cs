using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyElement : MonoBehaviour
{
    public void init()
    {
        Invoke("EXTERMINATE", 3f);
    }

    public void EXTERMINATE(){
        Destroy(gameObject);
    }
}
