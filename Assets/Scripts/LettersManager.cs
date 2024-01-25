using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LettersManager : MonoBehaviour
{
    public enum LetterType
    {
        L,
        A,
        U,
        G,
        H
    }

    [SerializeField]
    private List<LetterCtrl> lettersToBeCollected;

    [SerializeField]
    private LetterCtrl letterPrefab;

    [SerializeField]
    private float letterBoundsdistance = 50f;

    private LetterCtrl InstantiatedLetter;

    private Dictionary<LetterType, LetterCtrl> lettersDict = new Dictionary<LetterType, LetterCtrl>();

    private int _noOfLettersToBeCollected;

    private Bounds letterBounds;
  

    private void Start()
    {
        letterBounds = new Bounds(new Vector3(0f, 4f + letterBoundsdistance/2, 0f), 
            new Vector3(letterBoundsdistance, letterBoundsdistance, letterBoundsdistance));
        for (int i = 0; i < lettersToBeCollected.Count; i++)
        {
            lettersDict[lettersToBeCollected[i].LetterType] = lettersToBeCollected[i];
        }
        _noOfLettersToBeCollected = lettersToBeCollected.Count;
        StartCoroutine("GenerateLetterEgg");
    }

    private IEnumerator GenerateLetterEgg()
    {
        //while (_noOfLettersToBeCollected > 0 && InstantiatedLetter==null)
        //{
            yield return new WaitForSeconds(Random.Range(10f, 20f));
            Vector3 instantiatePos = new Vector3(
                Random.Range(letterBounds.min.x, letterBounds.max.x),
                letterBounds.min.y, 
                Random.Range(letterBounds.min.z, letterBounds.max.z)
                );
            InstantiateLetter(lettersToBeCollected[_noOfLettersToBeCollected - 1].LetterType, instantiatePos);
        StopCoroutine("GenerateLetterEgg");
        //}
        /*if(_noOfLettersToBeCollected <= 0)
        {
            StopCoroutine("GenerateLetterEgg");
        }*/
    }

    public void InstantiateLetter(LetterType letterType, Vector3 letterPos)
    {
        InstantiatedLetter = Instantiate(letterPrefab, letterPos, Quaternion.identity);
        InstantiatedLetter.SetLetterType(letterType);
    }

    public void CollectLetter()
    {
        lettersDict[InstantiatedLetter.LetterType].LetterGo.SetActive(true);
        _noOfLettersToBeCollected -= 1;
        Destroy(InstantiatedLetter.LetterGo);
        if (_noOfLettersToBeCollected > 0)
        {
            StartCoroutine("GenerateLetterEgg");
        }
        else
        {
            //call win the game to shout
        }
    }

}
