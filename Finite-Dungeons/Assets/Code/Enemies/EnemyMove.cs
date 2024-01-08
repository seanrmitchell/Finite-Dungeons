using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private float speed, awareRadius;

    private Transform target;

    void Awake()
    {
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= awareRadius)
        {
            // Distance between target and enemy is calculated & used to calculate angle based on tan y/x
            Vector2 rotation = target.position - transform.position;
            float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg - 90f;

            // Applies rotation in euler angles on the z-axis (2D rotation axis)
            transform.rotation = Quaternion.Euler(0f, 0f, angle);

            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, awareRadius);
    }
}
