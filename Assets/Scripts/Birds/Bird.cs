using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public abstract class Bird : MonoBehaviour
{
    [Header("Bird settings")]
    [SerializeField][Range(1, 10)] private float mass;


    [Header("Flight settings")]
    [SerializeField] private float minPull;
    [SerializeField] private float maxPull;
    [SerializeField] private float acceleration;
    [SerializeField] private float gravityMod;

    private Touch touch;
    private Vector3 startDragPosition;
    private Vector3 shotDirection;
    private float shotPull;
    //private PathDrawer pathDrawer;

    private bool isFlight;
    private bool isDestroyed;
    private bool isSkillReady;
    private GameObject UITouch;

    private Rigidbody2D rb;

    public void Instantiate()
    {
        //pathDrawer = GetComponent<PathDrawer>();
        isFlight = false;
        isDestroyed = false;
        isSkillReady = true;

        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.mass = mass;
        GetComponent<Collider2D>().enabled = false;
    }

    private void Awake()
    {
        Instantiate();
    }

    void Update()
    {
        if (isDestroyed) return;

        if (Input.touchCount > 0) touch = Input.GetTouch(0);
        if (UITouchCheck(touch)) return;

        if (isFlight)
        {
            Flight();
            if (isSkillReady && touch.phase == TouchPhase.Began)
            {
                isSkillReady = false;
                Skill();
            }
        }
        else
        {
            switch (touch.phase)
            {
                case TouchPhase.Began: Touch(); break;
                case TouchPhase.Moved: Drag(); break;
                case TouchPhase.Ended: Release(); break;
                default: break;
            }
        }
    }

    private bool UITouchCheck(Touch touch)
    {
        if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        {
            UITouch = EventSystem.current.currentSelectedGameObject;
            return true;
        }

        if (EventSystem.current.currentSelectedGameObject == null) return false;

        if (touch.phase == TouchPhase.Ended && EventSystem.current.currentSelectedGameObject.Equals(UITouch))
        {
            return true;
        }

        return false;
    }

    private void Touch()
    {
        startDragPosition = Camera.main.ScreenToWorldPoint(touch.position);
    }

    private void Drag()
    {
        Vector3 dragDirection = startDragPosition - Camera.main.ScreenToWorldPoint(touch.position);
        shotPull = Mathf.Clamp(Mathf.Abs(dragDirection.y) + dragDirection.x, minPull, maxPull);
        shotDirection = dragDirection.normalized;
        //отвести от точки и вращать вокруг неё

        //if (shotPull > 0f) pathDrawer.Draw(shotDirection, shotPull >= maxShotPull, spreadAngle);
    }

    private void Release()
    {
        //pathDrawer.Clear();
        if (shotPull <= 0) return;
        rb.bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Collider2D>().enabled = true;
        isFlight = true;
    }

    private void Flight()
    {
        rb.velocity = GetNextPointShift(ref shotDirection);
    }

    protected Vector3 GetNextPointShift(ref Vector3 direction)
    {
        direction.y += Time.fixedDeltaTime * -gravityMod * acceleration;
        return direction * Time.fixedDeltaTime * acceleration * shotPull * 100f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDestroyed) return;
        isDestroyed = true;
        rb.gravityScale = 1;
    }

    protected abstract void Skill();
}
