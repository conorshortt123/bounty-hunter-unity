using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFireCrate : MonoBehaviour
{
    private float fallSpeed = 5;
    public GameObject player;
    private WeaponsController ctrl;

    void Update()
    {
        transform.position += (Vector3.down * Time.deltaTime) * fallSpeed;
        float yValue = Mathf.Clamp(transform.position.y, -3.9f, 20);
        transform.position = new Vector3(transform.position.x, yValue, 0);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var playerCol = collider.GetComponent<CharacterController2D>();

        if (playerCol)
        {
            Debug.Log("Player collided");

            ctrl = player.GetComponentInChildren<WeaponsController>();

            if (ctrl)
            {
                Debug.Log("Weapons controller");
                //ctrl.setRapidFire();
                Destroy(gameObject);
            }
        }
    }
}
