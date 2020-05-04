using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GreenBulletBehavior : MonoBehaviour
{
    public float bulletSpeed = 1.5f;
    public float bulletDamage = 8.0f;
    public AnimationCurve BeatAnimation;
    public float maxTime = 0.0f;
    float chrono = 0.0f;

    private void Start()
    {
        this.GetComponent<SpriteRenderer>().material.color = GlobalColor.green;
    }

    private void Update()
    {

        chrono += Time.deltaTime;
        if (chrono > maxTime)
        {
            StartCoroutine(ExplodeGrenade());
            
        }

        float alpha = BeatAnimation.Evaluate(chrono);

        this.transform.Translate(Vector2.up * bulletSpeed * alpha, Space.Self);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Unit>().unitColor == Unit.CurrentColor.green)
        {
            collision.GetComponent<Unit>().unitHealth -= bulletDamage;
        }
        else
        {
            collision.GetComponent<Unit>().unitHealth -= bulletDamage * 0.45f;
        }

        if (collision.GetComponent<Animator>() != null)
        {
            collision.GetComponent<Animator>().SetTrigger("attacked");
        }
    }

    IEnumerator ExplodeGrenade()
    {
        this.gameObject.GetComponent<Animator>().SetTrigger("exploding");
        yield return new WaitForSeconds(1.3f);
        Destroy(this.gameObject);
    }

}
