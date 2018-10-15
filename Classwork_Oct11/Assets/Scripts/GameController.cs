using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player
{
    public Image panel;
    public Text text;
    public Button button;
}

[System.Serializable]
public class PlayerColor
{
    public Color panelColor;
    public Color textColor;
}

public class GameController : MonoBehaviour
{
    public Text[] buttonList;
    public GameObject gameOverPanel;
    public Text gameOverText;
    public GameObject restartButton;
    public Player playerX;
    public Player playerO;
    public PlayerColor activePlayerColor;
    public PlayerColor inactivePlayerColor;
    public GameObject startInfo;

    private string playerSide;
    private int moveCount;

    void Awake()
    {
        SetGameControllerReferenceOnButtons();
        gameOverPanel.SetActive(false);
        moveCount = 0;
        restartButton.SetActive(false);
    }

    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public void SetStartingSide(string startingSide)
    {
        playerSide = startingSide;
        if (playerSide == "X")
        {
            SetPlayerColors(playerX, playerO);
        }
        else
        {
            SetPlayerColors(playerO, playerX);
        }

        StartGame();
    }

    void StartGame()
    {
        SetBoardInteractable(true);
        SetPlayerButtons(false);
        startInfo.SetActive(false);
    }

    public string GetPlayerSide()
    {
        return playerSide;
    }

    public void EndTurn()
    {
        moveCount++;

        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver(playerSide);
        }
        else if (moveCount >= 9)
        {
            GameOver("draw");
        }
        else
        {
            ChangeSides();
        }
    }

    void ChangeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
        if (playerSide == "X")
        {
            SetPlayerColors(playerX, playerO);
        }
        else
        {
            SetPlayerColors(playerO, playerX);
        }
    }

    void SetPlayerColors(Player newPlayer, Player oldPlayer)
    {
        newPlayer.panel.color = activePlayerColor.panelColor;
        newPlayer.text.color = activePlayerColor.textColor;
        oldPlayer.panel.color = inactivePlayerColor.panelColor;
        oldPlayer.text.color = inactivePlayerColor.textColor;
    }

    void GameOver(string winningPlayer)
    {
        SetBoardInteractable(false);
        if (winningPlayer == "draw")
        {
            SetGameOverText("It's a Draw!");
            SetPlayerColorsInactive();
        }
        else
        {
            SetGameOverText(winningPlayer + " Wins!");
        }
        restartButton.SetActive(true);
    }

    void SetGameOverText(string value)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = value;
    }

    public void RestartGame()
    {
        moveCount = 0;
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
        SetPlayerButtons(true);
        SetPlayerColorsInactive();
        startInfo.SetActive(true);

        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].text = "";
        }
    }

    void SetBoardInteractable(bool toggle)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }

    void SetPlayerButtons(bool toggle)
    {
        playerX.button.interactable = toggle;
        playerO.button.interactable = toggle;
    }

    void SetPlayerColorsInactive()
    {
        playerX.panel.color = inactivePlayerColor.panelColor;
        playerX.text.color = inactivePlayerColor.textColor;
        playerO.panel.color = inactivePlayerColor.panelColor;
        playerO.text.color = inactivePlayerColor.textColor;
    }
}

/*
public class GameController : MonoBehaviour {

    public Text[] buttonTextList;
    public GameObject gameOverPanel;
    public Text gameOverText;

    private string playerSide;
    public int moveCount;

	// Use this for initialization
	void awake () {
        SetGameControllerReferenceOnButtons();
        playerSide = "X";
        gameOverPanel.SetActive(false);
        moveCount = 0;
	}
    public void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < buttonTextList.Length; i++)
        {
            buttonTextList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }
    public string GetPlayerSide()
    {
        return "?";
    }
    public void EndTurn()
    {
        
         //  0 1 2
         //  3 4 5
         //  6 7 8    

        moveCount++;
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
        if (moveCount >= 9)
        {
            gameOverPanel.SetActive(true);
            gameOverText.text = "It's a draw";
        }
    }
    void GameOver()
    {
        for(int i = 0; i < buttonTextList.Length; i++)
        {
            buttonTextList[i].GetComponentInParent<Button>().interactable = false;
        }
        SetGameOverText(playerSide + "Wins!");
    }

    void SetGameOverText (string value)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = value;
    }

    void ChangeSide()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
    }

    public void RestartGame()
    {
        playerSide = "X";
        moveCount = 0;
        gameOverPanel.SetActive(false);
        SetBoardInteractable(true);
        
        for (int i = 0; i < buttonTextList.Length; i++)
        {
            buttonTextList[i].text = "";
        }
    }

    void SetBoardInteractable(bool toggle)
    {
        for (int i = 0; i < buttonTextList.Length; i++)
        {
            buttonTextList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }
}
*/
