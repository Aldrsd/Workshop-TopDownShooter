using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject ExplosionFX;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Wall" || collision.transform.tag == "Ground")
        {
            if (ExplosionFX != null)
                Instantiate(ExplosionFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
