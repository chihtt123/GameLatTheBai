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
            this.imageTransfer();
        }
        Debug.Log(isFlipped +" "+  blockManager.CanFlip());
    }

    protected virtual void imageTransfer()
    {

        if (isFlipped)
        {
            Image buttonImage = this.GetComponent<Image>();
  
            int indexImage = this.value;
            buttonImage.sprite = blockManager.sprites[indexImage];      
        }
        else
        {
            UnflipCard();
        }
       
        
    }

    public void UnflipCard()
    {     
        isFlipped = false;
        Image buttonImage = this.GetComponent<Image>();
        buttonImage.sprite = blockManager.sprites[blockManager.sprites.Length-1];

    }


    public void SetValue(int value)
    {
        this.value = value;
    }
}
