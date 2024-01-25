using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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

    private int _maxLevel = 4;
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
}
