using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Pistol : MonoBehaviour
{
    [HideInInspector]
    public float damage;
    public float range;

    public int maxAmmo = 7;
    public int currentAmmo;
    public float reloadTime = 2f;
    public bool isReloading = false;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public AudioSource shoot;
    public GameObject impactEffect;

    FadeScript fade;

    void Start()
    {
        currentAmmo = maxAmmo;
        fade = FindObjectOfType<FadeScript>();
    }

    IEnumerator Reload()
    {
        isReloading = true;

        yield return new WaitForSeconds(reloadTime - .25f);
        yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;

        isReloading = false;
    }

    public void Shoot()
    {
        if (isReloading)
            return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        muzzleFlash.Play();
        shoot.Play();

        currentAmmo--;

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            PlayerController target = FindObjectOfType<PlayerController>();

            if (target != null)
            {
                target.health -= damage;
                fade.Out();
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}