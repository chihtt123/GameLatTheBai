using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockData : BlockAbstract
{
    [Header("BlockData")]
    public Node node;
    public Node Node => node;

    public virtual void setNode(Node node)
    {
        this.node = node;
    }

    public virtual void setSprite(Sprite sprite) 
    {

        if(sprite != null)
        {
            this.ctrl.sprite.sprite = sprite;
        }
       
    }

  
}
