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

    private void Start()
    {
        playerTransform = GameManager.instance.PlayerCtrl.playerTransform;
    }

    private void Update()
    {
        Debug.Log("calling");
        this.transform.LookAt(playerTransform);

        this.transform.Translate(0f, 0f, Time.deltaTime * forwardSpeed);
        if(Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
