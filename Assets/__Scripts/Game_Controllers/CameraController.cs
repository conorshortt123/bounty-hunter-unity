using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private CharacterController2D ctrl;
    private bool playerAlive;
    [SerializeField]private float clampRight = 130.0f;
    [SerializeField]private float clampLeft = -11.0f;

    void Start()
    {
        ctrl = player.GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerAlive = ctrl.getPlayerStatus();

        if (playerAlive)
        {
            transform.position = new Vector3((player.position.x + 4), -1, transform.position.z);
            float xValue = Mathf.Clamp(transform.position.x, clampLeft, clampRight);
            transform.position = new Vector3(xValue, -1, transform.position.z);
        }
    }
}
