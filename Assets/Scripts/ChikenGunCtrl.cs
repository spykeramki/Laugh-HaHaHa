using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChikenGunCtrl : WeaponCtrl
{
    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private GameObject loadedChicken;

    public float bulletSpeed = 10f;

    public override void Fire()
    {
        loadedChicken.SetActive(true);
        base.Fire();
        GameObject bullet = Instantiate(ammo, spawnPoint.position, spawnPoint.rotation);
        BulletCtrl bulletCtrl = bullet.GetComponent<BulletCtrl>();
        bulletCtrl.Rb.AddForce(spawnPoint.forward * bulletSpeed, ForceMode.Impulse);
        bulletCtrl.PlayChickenFlyAnimation(true);
        loadedChicken.SetActive(false);
        StartCoroutine("ManageLoadedChickenWhenFired");
    }

    private IEnumerator ManageLoadedChickenWhenFired()
    {
        yield return new WaitForSeconds(0.4f);
        loadedChicken.SetActive(true);
        StopCoroutine("ManageLoadedChickenWhenFired");

    }

}
