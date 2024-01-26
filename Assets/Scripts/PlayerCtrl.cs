using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [HideInInspector]
    public Transform playerTransform;

    public Transform camersTransform;

    private GameManager gameManager;

    private void Awake()
    {
        playerTransform = this.transform;
    }

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    private void Update()
    {
        RaycastHit hit;
        if (Input.GetMouseButton(1))
        {
            if (Physics.Raycast(camersTransform.position, camersTransform.forward, out hit, 50f))
            {
                if(hit.transform.tag == "Letter")
                {
                    hit.transform.LookAt(transform);
                    hit.transform.Translate(0f, 0f, Time.deltaTime * 3f);
                }
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            gameManager.isGameOver = true;
        }
        if (other.gameObject.tag == "Letter")
        {
            gameManager.LevelUp();
            gameManager.LettersManagerCtrl.CollectLetter();
        }
    }
}
