using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockItem : MonoBehaviour
{
    public int value;
    public int Value => value;
    [SerializeField] private bool isFlipped = false;
    [SerializeField] private BlockManager blockManager ;


    protected virtual void Start()
    {
        blockManager = FindObjectOfType<BlockManager>(); 
        GetComponent<Button>().onClick.AddListener(FlipCard);
    }

    public void FlipCard()
    {
        if (!isFlipped && blockManager.CanFlip()) 
        {

            isFlipped = true;

            blockManager.AddFlippedCard(this); 
        }
        Debug.Log(isFlipped +" "+  blockManager.CanFlip());
    }

    public void UnflipCard()
    {

        isFlipped = false;
      
    }


    public void SetValue(int value)
    {
        this.value = value;
    }
}
