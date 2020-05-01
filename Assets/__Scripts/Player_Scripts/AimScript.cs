using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour
{
    // private member variables
    private Vector2 mousePos;
    private Camera mainCamera;
    private Vector3 worldPosition;
    [SerializeField] private CharacterController2D controller;
    private float raiseLimit = 120;
    private float lowerLimit = -25;
    private float angleOffset = 26;

    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            bool FacingRight = controller.m_FacingRight;
            var dir = Input.mousePosition - mainCamera.WorldToScreenPoint(transform.position);

            // Flip mouse direction if character is facing left.
            if (!FacingRight)
            {
                dir *= -1;
                angleOffset *= -1;
            }
            else
            {
                angleOffset *= -1;
            }

            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            angle += angleOffset;

            // Limit angle of movement depending on if character is facing left or right
            if (FacingRight)
            {
                raiseLimit *= -1;
                lowerLimit *= -1;
                if (angle > lowerLimit && angle < raiseLimit)
                {
                    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                }
            }
            else if (!FacingRight)
            {
                raiseLimit *= -1;
                lowerLimit *= -1;
                if (angle < lowerLimit && angle > raiseLimit)
                {
                    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                }
            }
        }
    }
}