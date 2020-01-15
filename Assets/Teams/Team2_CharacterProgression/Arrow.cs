using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    GameObject target;
    public GameObject Target { set { target = value; } }
    public float moveSpeed = 10.0f;
    public int damage;
    public float destroyTimer = 3.0f;
    private bool destroy = false;

    // Update is called once per frame
    void Update()
    {
        if (destroy)
        {
            Destroy(gameObject);
        }
        destroyTimer -= Time.deltaTime;
        if (destroyTimer <= 0.0f)
        {
            destroy = true;
        }
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            Enemy enemy = other.GetComponentInParent<Enemy>();
            if (enemy)
            {
                enemy.TakeDamage(damage);
            }
            destroy = true;
        }
    }
}