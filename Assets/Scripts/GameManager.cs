using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Serializable]
    public struct Portals
    {
        public GameObject portalLv1;
        public GameObject portalLv2;
        public GameObject portalLv3;

    }

    [SerializeField]
    private Portals portals;

    private PlayerCtrl _playerCtrl;
    public PlayerCtrl PlayerCtrl
    {
        get => _playerCtrl;
    }

    private int _currentLevel = 1;
    public int CurrentLevel
    {
        get => _currentLevel;
    }

    private int _maxLevel = 3;
    public int MaxLevel
    {
        get => _maxLevel;
    }

    [SerializeField]
    private LettersManager lettersManager;

    public LettersManager LettersManagerCtrl
    {
        get => lettersManager;
    }

    [SerializeField]
    private GameOverCtrl gameOverCtrl;

    public bool isGameOver = false;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance== null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Start()
    {
        _playerCtrl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCtrl>();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void LevelUp()
    {
        if (_currentLevel < MaxLevel)
        {
            _currentLevel++;
        }
        if (_currentLevel == 2)
        {
            portals.portalLv2.SetActive(true);
        }
        else if(_currentLevel == 3)
        {
            portals.portalLv3.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadSceneAsync("01Main");
    }

    public void GoToHome()
    {
        SceneManager.LoadSceneAsync("00Start");
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverCtrl.DisplayEndOfTheGame(!isGameOver);
    }

    public void WonGame()
    {
        isGameOver = true;
        gameOverCtrl.DisplayEndOfTheGame(isGameOver);
    }


}
