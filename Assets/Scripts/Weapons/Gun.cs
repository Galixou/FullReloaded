using UnityEngine;

public class Gun : MonoBehaviour
{
    [HideInInspector]
    public float damage;
    private float range;
    private float fireRate = 10f;
    private float impactForce;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public AudioSource shoot;
    public GameObject impactEffect;

    private float nextTimeToFire = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            damage = Random.Range(1f, 10f);
            range = Random.Range(1f, 100f);
            impactForce = Random.Range(1f, 30f);

            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        shoot.Play();
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            EnemyDamage target = hit.transform.GetComponent<EnemyDamage>();

            if(target != null)
            {
                target.TakeDamage(damage);
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}
