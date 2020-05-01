using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // used to identify bullet
    
    void Update()
    {
        Destroy(gameObject, 3.0f);
    }
}
