using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    [SerializeField]
    private float level;

    private float forwardSpeed = 5f;

    private float health;

    public float Health
    {
        get => health;
    }

    private Transform playerTransform;

    private GameManager gameManager;


    private void Start()
    {
        gameManager = GameManager.instance;
        playerTransform = gameManager.PlayerCtrl.playerTransform;
        health = 100 * (level / 2);
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
            float healthReduce = 50f;
            EnemyDeath(healthReduce);
        }
    }

    private void EnemyDeath(float healthReduce)
    {
        health -= healthReduce;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
