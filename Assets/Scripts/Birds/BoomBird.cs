using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBird : Bird
{
    [Header("Boom bird settings")]
    [SerializeField] private float boomForce;
    public List<Rigidbody2D> booms;

    public override void Instantiate()
    {
        base.Instantiate();
        booms = new List<Rigidbody2D>();
    }

    protected override void Ability()
    {
        StartCoroutine("BoomTimer");
    }

    protected override void Destroy()
    {
        Boom();
        base.Destroy();
    }

    private IEnumerator BoomTimer()
    {
        yield return new WaitForSeconds(1);
        Boom();
        Destroy();
    }

    private void Boom()
    {
        Vector2 position = transform.position;
        booms.ForEach(rb => {
            var forceDirection = rb.position - position;
            rb.AddForce(forceDirection.normalized * boomForce);
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var rb = collision.GetComponent<Rigidbody2D>();
        if (rb == null) return;
        booms.Add(rb);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var rb = collision.GetComponent<Rigidbody2D>();
        if (rb == null) return;
        booms.Remove(rb);
    }
}
