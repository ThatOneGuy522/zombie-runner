using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] float timeBetweenShots = 0.5f;

    [SerializeField] bool canShoot = true;

    //private void OnDisable()
    //{
    //    canShoot = false;
    //}

    private void OnEnable()
    {
        canShoot = true;
    }

    private void Update()
    {
        Debug.Log("Current range:" + range);
        Debug.Log("Current damage:" + damage);
    }

    //public IEnumerator Shoot()
    //{

    //    if (ammoSlot.GetCurrentAmmo() > 0 && canShoot == true)
    //    {
    //        canShoot = false;
    //        PlayMuzzleFlash();
    //        ProcessRaycast();
    //        ammoSlot.ReduceCurrentAmmo();
    //    }
    //    yield return new WaitForSeconds(timeBetweenShots);
    //    canShoot = true;
    //}

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) { return; }
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1);
    }
}
