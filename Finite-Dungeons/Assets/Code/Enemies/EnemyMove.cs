using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private float speed, awareRadius;

    private GameObject target;

    void Awake()
    {
        target = GameObject.Find("Player");
    }

    void Update()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);

        if (distance <= awareRadius)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, awareRadius);
    }
}
