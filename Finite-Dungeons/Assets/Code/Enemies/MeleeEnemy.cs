using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [SerializeField]
    private float damage;

    [SerializeField]
    private float attackCoolDown, attackRange;

    [SerializeField]
    private LayerMask playerLayer;

    private float attackSpeed;

    // Start is called before the first frame update
    void Start()
    {
        attackSpeed = attackCoolDown;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Collider[] hitPlayer = Physics.OverlapSphere(transform.position, attackRange, playerLayer);

        foreach (Collider player in hitPlayer)
        {
            if (attackSpeed >= attackCoolDown)
            {
                Debug.Log("Player Hit!");
                //player.gameObject.GetComponent<PlayerCondition>().UpdateHealth(damage);
                attackSpeed = 0f;
            }
        }

        if (attackSpeed < attackCoolDown)
        {
            attackSpeed += Time.deltaTime;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
