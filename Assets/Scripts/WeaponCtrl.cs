using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCtrl : MonoBehaviour
{
    [SerializeField]
    protected GameObject ammo;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    public virtual void Fire()
    {

    }

    protected virtual void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameManager.isGameOver)
        {
            Fire();
        }
    }
}
