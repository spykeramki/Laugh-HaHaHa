using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpCtrl : MonoBehaviour
{
    private Vector3 playerVelocity = Vector3.zero;
    private float lookSpeed = 5f;
    private bool groundedPlayer;
    private float gravityValue = -9.81f;
    private Rigidbody rb;
    public Transform playerCamera;
    private float rotX = 0;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!gameManager.isGameOver)
        {
            rotX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotX = Mathf.Clamp(rotX, -50, 50);


            playerCamera.localRotation = Quaternion.Euler(rotX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

    }


}