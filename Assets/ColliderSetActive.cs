using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSetActive : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coins")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
