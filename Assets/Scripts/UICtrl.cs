using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class UICtrl : MonoBehaviour
{
    public Button PlayBtn;
    public Button YesBtnToQuit;
    public GameObject PrevVideoBtnGo;
    public GameObject NextVideoBtnGo;
    public Button PrevVideoBtn;
    public Button NextVideoBtn;

    public List<GameObject> instructionList;
    private int _currentClipIndex = 0;

    void Start()
    {
        PlayBtn.onClick.AddListener(StartGame);
        YesBtnToQuit.onClick.AddListener(QuitGame);
        PrevVideoBtn.onClick.AddListener(OnClickPrevBtn);
        NextVideoBtn.onClick.AddListener(OnClickNextBtn);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void StartGame()
    {
        SceneManager.LoadScene("01Main");
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    public void OnEnableInstructions()
    {
        _currentClipIndex = 0;
        PrevVideoBtnGo.SetActive(false);
        NextVideoBtnGo.SetActive(true);
        instructionList[_currentClipIndex].SetActive(true);
    }

    private void OnClickNextBtn()
    {
        instructionList[_currentClipIndex].SetActive(false);
        _currentClipIndex += 1;
        //Debug.Log(_currentClipIndex + "_currentClipIndex OnClickNextBtn");
        
        if(_currentClipIndex < instructionList.Count)
        {
            if (_currentClipIndex >= instructionList.Count - 1)
            {
                NextVideoBtnGo.SetActive(false);
            }

            instructionList[_currentClipIndex].SetActive(true);
        }
        PrevVideoBtnGo.SetActive(true);

    }
    private void OnClickPrevBtn()
    {
        instructionList[_currentClipIndex].SetActive(false);
        _currentClipIndex -= 1;
        //Debug.Log(_currentClipIndex + "_currentClipIndex OnClickPrevBtn");
        
        if(_currentClipIndex >= 0)
        {
            if (_currentClipIndex <= 0)
            {
                PrevVideoBtnGo.SetActive(false);
            }

            instructionList[_currentClipIndex].SetActive(true);
        }
        NextVideoBtnGo.SetActive(true);
    }
}
