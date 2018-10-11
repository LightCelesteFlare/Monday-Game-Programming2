using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text[] buttonTextList;
    private string playerSide;
    public void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < buttonTextList.Length; i++)
        {
            buttonTextList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }
	// Use this for initialization
	void awake () {
        SetGameControllerReferenceOnButtons();
        playerSide = "X";
	}
	
    public string GetPlayerSide()
    {
        return playerSide;
    }
    public void EndTurn()
    {
        /*
         *  0 1 2
         *  3 4 5
         *  6 7 8
         * 
         */
        Debug.Log("EndTurn is not implemented!");
        // Horizational
        if (buttonTextList[0].text == playerSide && buttonTextList[1].text == playerSide && buttonTextList[2].text == playerSide)
        {
            GameOver();
        }
        if (buttonTextList[3].text == playerSide && buttonTextList[4].text == playerSide && buttonTextList[5].text == playerSide)
        {
            GameOver();
        }
        if (buttonTextList[6].text == playerSide && buttonTextList[7].text == playerSide && buttonTextList[8].text == playerSide)
        {
            GameOver();
        }
        // Vertical
        if (buttonTextList[0].text == playerSide && buttonTextList[3].text == playerSide && buttonTextList[8].text == playerSide)
        {
            GameOver();
        }
        if (buttonTextList[1].text == playerSide && buttonTextList[4].text == playerSide && buttonTextList[7].text == playerSide)
        {
            GameOver();
        }
        if (buttonTextList[2].text == playerSide && buttonTextList[5].text == playerSide && buttonTextList[8].text == playerSide)
        {
            GameOver();
        }
        // cross
        if (buttonTextList[0].text == playerSide && buttonTextList[4].text == playerSide && buttonTextList[8].text == playerSide)
        {
            GameOver();
        }
        if (buttonTextList[2].text == playerSide && buttonTextList[4].text == playerSide && buttonTextList[6].text == playerSide)
        {
            GameOver();
        }
        ChangeSide();
    }
    void GameOver()
    {
        for(int i = 0; i < buttonTextList.Length; i++)
        {
            buttonTextList[i].GetComponentInParent<Button>().interactable = false;
        }
    }
    void ChangeSide()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
    }
}
