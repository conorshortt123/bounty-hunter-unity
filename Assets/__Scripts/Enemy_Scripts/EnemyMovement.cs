using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private GameObject target;
    [SerializeField] private AudioClip clip;
    private AudioSource audioSource;
    private Rigidbody2D rb;
    private float maxDist = 10; // Play sound from a max distance of x units from player
    private float timer;
    private float soundTimer = 2.0f;
    private float volume, distance, temp;

    void Start()
    {
        target = GameObject.Find("Cowboy");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!PauseMenu.isPaused)
        {
            if (target)
            {
                distance = Vector3.Distance(transform.position, target.transform.position);
                temp = distance / maxDist;
                volume = 0.5f - temp;
        
                transform.LookAt(target.transform.position);
                transform.Rotate(new Vector3(0, 90, 0), Space.Self); //correcting the original rotation
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            }   

            if (timer > soundTimer)
            {
                audioSource.PlayOneShot(clip, volume);
                timer = 0;
            } else
            {
                timer += Time.deltaTime;
            }
        }
    }
}
