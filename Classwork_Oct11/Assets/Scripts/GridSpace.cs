using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour {
    public Button button;
    public Text buttontext;

    private GameController gameController;
    // Use this for initialization
    public void SetSpace()
    {
        buttontext.text = gameController.GetPlayerSide();
        button.interactable = false;
        gameController.EndTurn();
    }
    public void SetGameControllerReference(GameController g)
    {
        gameController = g;
    }
}
