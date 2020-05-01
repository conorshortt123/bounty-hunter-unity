using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillainShoot : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 15.0f;
    [SerializeField] private VillainBullet bulletPrefab;
    [SerializeField] private float firingRate = 0.4f;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject player;
    [SerializeField] private float speed = 2.0f;
    private Coroutine firingCoroutine;
    private GameObject bulletParent;
    private SoundController sc;
    private bool startFire = false;
    private bool called = false;
    private float distance;
    private bool FacingRight = false;

    public AudioClip shootClip;

    // Start is called before the first frame update
    void Start()
    {
        Flip();

        // Create bullet parent object
        bulletParent = GameObject.Find("VillainBullets");
        if (!bulletParent)
        {
            bulletParent = new GameObject("VillainBullets");
        }

        sc = SoundController.FindSoundController();
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            if (startFire && !called)
            {
                firingCoroutine = StartCoroutine(FireCoroutine());

                called = true;
            }

            distance = Vector2.Distance(transform.position, player.transform.position);

            if (distance < 15)
            {
                startFire = true;
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);
            }
        }
    }

    // Coroutine returns an IEnumerator type
    private IEnumerator FireCoroutine()
    {
        while (true)
        {
            // Create a bullet on the transform Fire Point so bullet fires from the gun barrel
            // Instantiate bullet
            VillainBullet bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rbb = bullet.GetComponent<Rigidbody2D>();

            // Play shooting sound
            if (sc)
            {
                sc.PlayOneShot(shootClip);
            }
            
            bullet.transform.rotation *= Quaternion.Euler(0, 0, 90);
            rbb.velocity = -firePoint.right * bulletSpeed;

            yield return new WaitForSeconds(firingRate);
        }
    }

    public void Flip()
    {
        // Switch the way the player is labelled as facing.
        FacingRight = !FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
