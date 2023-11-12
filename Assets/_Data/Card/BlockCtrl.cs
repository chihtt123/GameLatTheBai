using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCtrl : ChiMonoBehaviour
{
    public  SpriteRenderer sprite;
   
    public BlockData blockData;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadData();
     

    }
    protected virtual void LoadModel()
    {
        if (this.sprite != null) return;
        Transform model = transform.Find("Model");
        this.sprite = model.GetComponent<SpriteRenderer>();
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }

    
    protected virtual void LoadData()
    {
        if (this.blockData != null) return;

        this.blockData = transform.Find("BlockData").GetComponent<BlockData>();
        Debug.Log(transform.name + ": LoadData", gameObject);
    }

   
}
