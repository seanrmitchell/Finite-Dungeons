using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{

    public Transform firePos;
    public GameObject shootPrefab;

    [SerializeField]
    private float damage, fireForce;

    [SerializeField]
    private float attackCoolDown;

    private float attackSpeed;

    // Start is called before the first frame update
    void Start()
    {
        attackSpeed = attackCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackSpeed >= attackCoolDown) {
            Shoot();
            attackSpeed = 0f;
        }
        

        if (attackSpeed < attackCoolDown)
        {
            attackSpeed += Time.deltaTime;
        }
    }

    void Shoot()
    {
        // Creates a clone using "missile" prefab, applies damage, and applies a force to propel
        GameObject laser = Instantiate(shootPrefab, firePos.position, firePos.rotation);
        Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
        laser.GetComponent<Missile>().damage = damage;
        rb.AddForce(firePos.up * fireForce, ForceMode2D.Impulse);
    }
}

