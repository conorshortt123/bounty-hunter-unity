using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpawner : MonoBehaviour
{
    [SerializeField] private GameObject tumbleWeedPrefab;
    [SerializeField] private float spawnDelay = 2.0f;
    private float speed;
    private float timer;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            speed = Random.Range(1.0f, 10.0f);
            spawnDelay = Random.Range(0.5f, 2.0f);
            GameObject tumbleWeed = Instantiate(tumbleWeedPrefab, gameObject.transform);
            Rigidbody2D rb = tumbleWeed.GetComponent<Rigidbody2D>();
            Destroy(tumbleWeed, 5.0f);

            rb.AddForce(Vector2.left * speed);

            yield return new WaitForSeconds(spawnDelay);
        }
    }
} 
