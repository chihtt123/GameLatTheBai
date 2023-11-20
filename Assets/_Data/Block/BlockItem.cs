using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockItem : MonoBehaviour 
{
    public int value;
    private bool isFlipped = false;
   
    public void SetValue(int value)
    {
        this.value = value;
    }
}
