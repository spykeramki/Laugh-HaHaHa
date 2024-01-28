using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCtrl : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverGo;

    [SerializeField]
    private GameObject wonGo;

    private GameObject parentGo;

    private void Awake()
    {
        parentGo = this.gameObject;
    }

    public void DisplayEndOfTheGame(bool isWonTheGame) 
    {
        parentGo.SetActive(true);
        wonGo.SetActive(isWonTheGame);
        gameOverGo.SetActive(!isWonTheGame);
    }
}
