using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterCtrl : MonoBehaviour
{
    [SerializeField]
    private LettersManager.LetterType letterType;

    public LettersManager.LetterType LetterType
    {
        get => letterType;
    }

    public GameObject LetterGo
    {
        get => this.gameObject;
    }

    public void SetLetterType(LettersManager.LetterType letter)
    {
        letterType = letter;
    }
}
