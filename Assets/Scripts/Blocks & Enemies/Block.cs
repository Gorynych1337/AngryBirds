using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private float maxHP;
    [SerializeField][Range(1, 10)] private float mass;
    [SerializeField] private int score;

    private Rigidbody2D rb;
    private float hp;
    private bool isDestroyed;

    public delegate void BlockScore(int score);
    public static event BlockScore OnBlockDestroyed;

    private void Awake()
    {
        hp = maxHP;
        rb = GetComponent<Rigidbody2D>();
        rb.mass = mass;
        isDestroyed = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D hitRb = collision.transform.GetComponent<Rigidbody2D>();

        if (hitRb == null && collision.gameObject.tag != "Ground") return;

        Vector2 hitImpuls = collision.relativeVelocity;

        if (hitRb != null)
        {
            hitImpuls *= hitRb.mass;
        }

        hp -= hitImpuls.magnitude;
        if (hp <= 0) Destroy();
    }

    protected void Destroy()
    {
        if (isDestroyed) return;
        isDestroyed = true;
        OnBlockDestroyed?.Invoke(score);
        Destroy(gameObject);
    }
}
