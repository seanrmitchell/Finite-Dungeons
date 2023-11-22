using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform firePos;
    public GameObject shootPrefab;
    public Controller playerShoot;

    [SerializeField]
    private float fireForce;

    private void Awake()
    {
        playerShoot = new Controller();
    }

    private void OnEnable()
    {
        playerShoot.Enable();
    }
    private void OnDisable()
    {
        playerShoot.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerShoot.Attack.Fire.performed += _ => Shoot();
    }

    void Shoot()
    {
        GameObject laser = Instantiate(shootPrefab, firePos.position, firePos.rotation);
        Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
        rb.AddForce(firePos.up * fireForce, ForceMode2D.Impulse);
    }
}
