using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillainBullet : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 5.0f);
    }

}
