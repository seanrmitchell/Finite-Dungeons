using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Missile : MonoBehaviour
{
    public GameObject collExplode;
    
    public float damage;

    public float volume;

    public AudioClip clip;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player"))
        {
            collision.gameObject.GetComponent<Health>().UpdateHealth(damage);
        }

        GameObject explosion = (GameObject) Instantiate (collExplode, transform.position, transform.rotation);
        explosion.GetComponent<AudioSource>().PlayOneShot(clip, volume);
        Destroy(explosion, clip.length);

        Destroy(gameObject);


    }
}
