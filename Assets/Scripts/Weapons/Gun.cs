using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class Gun : MonoBehaviour
{
    [HideInInspector]
    public float damage;
    private float range;
    private float fireRate = 10f;

    private int maxAmmo = 30;
    private int currentAmmo;
    private float reloadTime = 1.5f;
    private bool isReloading = false;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public AudioSource shoot;
    public GameObject impactEffect;

    private float nextTimeToFire = 0f;

    public Animator anim;
    public TextMeshProUGUI ammoDisplay;


    void Start()
    {
        currentAmmo = maxAmmo;
    }

    private void OnEnable()
    {
        isReloading = false;
        anim.SetBool("Reloading", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
            return;

        if(currentAmmo <= 0 || Input.GetButton("Reload") && currentAmmo <= 29)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            damage = Random.Range(5f, 20f);
            range = Random.Range(25f, 35f);

            if(Time.timeScale == 1)
                Shoot();
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;

        anim.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - .25f);
        anim.SetBool("Reloading", false);
        yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;
        ammoDisplay.text = 30 + " / " + maxAmmo.ToString();
        isReloading = false;
    }

    void Shoot()
    {
        muzzleFlash.Play();
        shoot.Play();

        currentAmmo--;
        ammoDisplay.text = currentAmmo.ToString() + " / " + maxAmmo.ToString();

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Enemy target = hit.transform.GetComponent<Enemy>();

            if(target != null)
            {
                target.TakeDamage(damage);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}
