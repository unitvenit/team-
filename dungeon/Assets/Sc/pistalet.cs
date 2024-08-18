using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pistalet : MonoBehaviour
{
    public float damage;
    public float firerate;
    public Transform bulletPos;
    public float range = 15;
    public GameObject muzzleFlash;
    public AudioClip shotSFX;
    public AudioSource audioSource;

    public Camera camera;
    public Animator animator;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    void Shoot()
    {
        animator.SetTrigger("Shoot");

        audioSource.PlayOneShot(shotSFX);
        Instantiate(muzzleFlash, bulletPos.position, bulletPos.rotation);

        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
            Debug.Log("попал " + hit.collider);

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(hit.normal * -400);
            }
        }
    }
}
