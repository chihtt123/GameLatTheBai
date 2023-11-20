using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockItem : MonoBehaviour 
{
    public int value;
    private bool isFlipped = false;
    private BlockManager game;
   
    public void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
        isFlipped = true;
    }

    public void InitializeCard(int value, BlockManager game)
    {
        this.value = value;
        this.game = game;
    }


    public void SetValue(int value)
    {
        this.value = value;
    }
}
