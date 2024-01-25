using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    [SerializeField]
    private float level;

    private float forwardSpeed = 5f;

    private float basicHealth = 100f;

    public float Health
    {
        get => basicHealth * (level/2);
    }

    private Transform playerTransform;

    private GameManager gameManager;


    private void Start()
    {
        gameManager = GameManager.instance;
        playerTransform = gameManager.PlayerCtrl.playerTransform;
    }

    private void Update()
    {
        if (!gameManager.isGameOver)
        {
            this.transform.LookAt(playerTransform);

            this.transform.Translate(0f, 0f, Time.deltaTime * forwardSpeed);
            if (Health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            EnemyDeath();
        }
    }

    private void EnemyDeath()
    {
        Destroy(gameObject);
    }
}
