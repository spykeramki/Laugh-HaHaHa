using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{

    private float selfDestructTime = 10f;

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
        Destroy(gameObject);
    }
}
