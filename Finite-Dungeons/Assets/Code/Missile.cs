using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float damage;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player"))
        {
            collision.gameObject.GetComponent<Health>().UpdateHealth(damage);
        }

        Destroy(gameObject);
    }
}
