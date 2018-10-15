using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour {
    public Button button;
    public Text buttonText;

    private GameController gameController;

    public void SetGameControllerReference(GameController controller)
    {
        gameController = controller;
    }

    public void SetSpace()
    {
        buttonText.text = gameController.GetPlayerSide();
        button.interactable = false;
        gameController.EndTurn();
    }
}
//public class GridSpace : MonoBehaviour
//{
//    public Button button;
//    public Text buttontext;
//    //public string playerSide;
//    private GameController gameController;
//    // Use this for initialization

//    public void SetGameControllerReference(GameController controller)
//    {
//        gameController = controller;
//    }
//    public void SetSpace()
//    {
//        //buttontext.text = playerSide;
//        buttontext.text = gameController.GetPlayerSide();
//        button.interactable = false;
//        gameController.EndTurn();
//    }
//}