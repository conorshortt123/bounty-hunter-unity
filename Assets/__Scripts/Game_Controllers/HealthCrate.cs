using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCrate : MonoBehaviour
{
    [SerializeField] private int healthCrate = 20;
    private float fallSpeed = 5;

    void Update()
    {
        transform.position += (Vector3.down * Time.deltaTime) * fallSpeed;
        float yValue = Mathf.Clamp(transform.position.y, -3.9f, 20);
        transform.position = new Vector3(transform.position.x, yValue, 0);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var player = collider.GetComponent<CharacterController2D>();

        if (player)
        {
            // Adds 20 health to player.
            player.AddPlayerHealth(healthCrate);
            Destroy(gameObject);
        }
    }
}