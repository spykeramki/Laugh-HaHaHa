using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{

    [SerializeField]
    private Animator anim;

    private float selfDestructTime = 10f;

    private Rigidbody rb;
    public Rigidbody Rb
    {
        get => rb;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        StartCoroutine("AutoDestructBullet");
    }

    private IEnumerator AutoDestructBullet()
    {
        yield return new WaitForSeconds(selfDestructTime);
        StopCoroutine("AutoDestructBullet");
        DestroyBullet();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        PlayChickenFlyAnimation(false);
        Destroy(gameObject);
    }

    public void PlayChickenFlyAnimation(bool isFlying)
    {
        anim.SetBool("Run", isFlying);
    }
}
