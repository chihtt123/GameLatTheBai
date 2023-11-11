using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockData : BlockAbstract
{
    [Header("BlockData")]
    public Node node;

    public virtual void setNode(Node node)
    {
        this.node = node;
    }

    public virtual void setSprite(Sprite sprite) 
    {
        this.ctrl.sprite.sprite = sprite;
        this.ctrl.sprite.size = new Vector2 (this.ctrl.sprite.size.x * 0.2f, this.ctrl.sprite.size.y * 0.2f);
       }
}
