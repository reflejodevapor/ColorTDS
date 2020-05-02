using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBulletBehavior : MonoBehaviour
{
    public float bulletSpeed = 1.5f;

    private void Start()
    {
        this.GetComponent<SpriteRenderer>().material.color = Color.red;
    }

    private void Update()
    {
        this.transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime, Space.Self);
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
