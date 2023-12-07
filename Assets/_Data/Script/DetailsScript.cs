using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DetailsScript : MonoBehaviour
{
    [SerializeField] public TMP_Text scoreText;
    [SerializeField] public TMP_Text remainingTurnText;
    [SerializeField] public TMP_Text correctPairText;
   


    protected  virtual void FixedUpdate()
    {
       
        UpdateText();

    }


    protected virtual void UpdateText()
    {
        scoreText.text = "Score : " + BlockManager.Instance.Score;
        remainingTurnText.text = "RemainingTurn Text : " + (BlockManager.Instance.remainingTurn);
        correctPairText.text = "Correct Pair : " + BlockManager.Instance.correctPair;
    }
}    
