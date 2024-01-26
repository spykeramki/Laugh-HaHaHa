using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChikenGunCtrl : WeaponCtrl
{
    [SerializeField]
    private Transform spawnPoint;

    public float bulletSpeed = 10f;

    public override void Fire()
    {
        base.Fire();
        GameObject bullet = Instantiate(ammo, spawnPoint.position, spawnPoint.rotation);
        BulletCtrl bulletCtrl = bullet.GetComponent<BulletCtrl>();
        bulletCtrl.Rb.AddForce(spawnPoint.forward * bulletSpeed, ForceMode.Impulse);
        bulletCtrl.PlayChickenFlyAnimation(true);
    }

}
