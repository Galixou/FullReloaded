using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{

    public Animator anim;

    [HideInInspector]
    public float degats;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && this.gameObject.activeSelf)
        {
            anim.Play("KnifeAttack");
            degats = Random.Range(1f, 20f);
        }
    }
}
