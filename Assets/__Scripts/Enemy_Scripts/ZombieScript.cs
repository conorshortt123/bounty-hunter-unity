using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private GameObject target;
    bool facingRight = false;

    // Update is called once per frame
    void Update()
    {
        /*float DotResult = Vector3.Dot((transform.position - target.transform.position), transform.right);
        Debug.Log("Dot result = " + DotResult);

        if (DotResult > 0)
        {
            if (!facingRight)
            {
                Flip();
            }
            transform.position += -transform.right * Time.deltaTime;
        } else
        {
            if (facingRight)
            {
                Flip();
            }
            transform.position += transform.right * Time.deltaTime;
        }*/

        transform.LookAt(target.transform.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self); //correcting the original rotation
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
