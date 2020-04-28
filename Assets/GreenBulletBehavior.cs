using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBulletBehavior : MonoBehaviour
{
    public float bulletSpeed = 1.5f;
    public AnimationCurve BeatAnimation;
    public float maxTime = 0.0f;
    public float chrono = 0.0f;
    public float BPM = 0.0f;

    private void Start()
    {
        this.GetComponent<SpriteRenderer>().material.color = Color.green;
    }

    private void Update()
    {

        chrono += Time.deltaTime;
        if (chrono > maxTime)
        {
            Destroy(this.gameObject);
        }

        float alpha = BeatAnimation.Evaluate(chrono);

        this.transform.Translate(Vector2.up * bulletSpeed * alpha, Space.Self);
    }

    private void OnBecameInvisible()
    {
        
    }
}
