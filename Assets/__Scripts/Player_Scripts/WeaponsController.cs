using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponsController : MonoBehaviour
{
    // == private fields ==
    [SerializeField] private float bulletSpeed = 15.0f;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float firingRate = 0.4f;
    [SerializeField] private Transform firePoint;
    [SerializeField] private CharacterController2D controller;
    [SerializeField] private int clipSize = 6;
    [SerializeField] private float reloadTime = 1.0f;
    private float timer;
    private bool reloading = false;
    private int currentAmmo;
    private bool FacingRight;
    private Coroutine firingCoroutine;
    private GameObject bulletParent;
    private SoundController sc;

    // == public fields ==
    public AudioClip reloadClip;
    public AudioClip shootClip;
    public TextMeshProUGUI ammoHUD;
    public Transform shot1, shot2, shot3, shot4, shot5, shot6;

    private void Start()
    {
        // Set currentAmmo equal to clip size
        currentAmmo = clipSize;

        bulletParent = GameObject.Find("BulletParent");
        if (!bulletParent)
        {
            bulletParent = new GameObject("BulletParent");
        }

        // find the sound controller
        sc = SoundController.FindSoundController();
    }

    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            FacingRight = controller.m_FacingRight;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                firingCoroutine = StartCoroutine(FireCoroutine());
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                // Stop the routine once the mouse button is let go
                if (firingCoroutine != null)
                {
                    StopCoroutine(firingCoroutine);
                }
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                reloading = true;
                if (sc)
                {
                    sc.PlayOneShot(reloadClip, 1.0f);
                }
            }

            if (reloading)
            {
                Reload();
            }
        }
    }

    // Coroutine returns an IEnumerator type
    private IEnumerator FireCoroutine()
    {
        while (true)
        {
            if (!reloading)
            {
                Fire();
            }
            yield return new WaitForSeconds(firingRate);
        }
    }

    private void Reload()
    {
        if (timer < reloadTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            reloading = false;
            timer = 0;
            currentAmmo = clipSize;
            UpdateAmmoHUD();
        }
    }

    public void UpdateAmmoHUD()
    {
        string ammoAmount = currentAmmo.ToString();

        // Update bullet GUI.
        ammoHUD.SetText(ammoAmount);

        shot1.GetComponent<Image>().enabled = (currentAmmo > 0);
        shot2.GetComponent<Image>().enabled = (currentAmmo > 1);
        shot3.GetComponent<Image>().enabled = (currentAmmo > 2);
        shot4.GetComponent<Image>().enabled = (currentAmmo > 3);
        shot5.GetComponent<Image>().enabled = (currentAmmo > 4);
        shot6.GetComponent<Image>().enabled = (currentAmmo > 5);
    }

    private void Fire()
    {
        // Instantiate bullet
        Bullet bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation, bulletParent.transform);
        Rigidbody2D rbb = bullet.GetComponent<Rigidbody2D>();

        // Play shooting sound
        if (sc)
        {
            sc.PlayOneShot(shootClip);
        }

        // Update ammo
        currentAmmo--;
        UpdateAmmoHUD();

        // Reload check and play audio clip if reloading
        if (currentAmmo <= 0)
        {
            reloading = true;

            if (sc)
            {
                sc.PlayOneShot(reloadClip);
            }
        }

        /*
        * Fire bullet in the direction the player is facing.
        * If player is facing right, set velocity equal to firePoint.right,
        * else set it to the negative of right (left of course).
        * Also rotate the bullet to face the direction the player is aiming.
        */
        if (FacingRight)
        {
            bullet.transform.rotation *= Quaternion.Euler(0, 0, -90);
            rbb.velocity = firePoint.right * bulletSpeed;
        }
        else
        {
            bullet.transform.rotation *= Quaternion.Euler(0, 0, 90);
            rbb.velocity = -firePoint.right * bulletSpeed;
        }
    }
}
