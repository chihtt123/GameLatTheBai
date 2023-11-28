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
    

      void Start()
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
            this.ImageTransfer();
        }
        Debug.Log(isFlipped +" "+  blockManager.CanFlip());
    }

      void ImageTransfer()
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
