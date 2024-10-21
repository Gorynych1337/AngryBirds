using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public abstract class Bird : MonoBehaviour
{
    [Header("Bird settings")]
    [SerializeField][Range(1, 10)] private float mass;
    [SerializeField] private FlightSettings flightSettings;
    [SerializeField] private SoundsPreset birdLaugh;

    protected float acceleration;
    protected float gravityMod;

    public delegate void BirdDestroyed();
    public static event BirdDestroyed OnBirdDestroyed;

    private Touch touch;
    private Vector3 startDragPosition;
    private Vector3 startBirdPosition;
    private Vector3 shotDirection;
    private float shotPull;
    //private PathDrawer pathDrawer;

    private bool isFlight;
    private bool isDestroyed;
    private bool isSkillReady;
    private GameObject UITouch;

    private Rigidbody2D rb;

    public virtual void Instantiate()
    {
        acceleration = flightSettings.acceleration;
        gravityMod = flightSettings.gravityMod;

        isFlight = false;
        isDestroyed = false;
        isSkillReady = true;

        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.mass = mass;
        GetComponent<Collider2D>().enabled = false;
    }

    protected virtual void Awake()
    {
        Instantiate();
    }

    protected virtual void Update()
    {
        if (isDestroyed) return;

        if (Input.touchCount > 0) touch = Input.GetTouch(0);
        if (UITouchCheck(touch)) return;

        if (isFlight)
        {
            if (isSkillReady && touch.phase == TouchPhase.Began)
            {
                isSkillReady = false;
                Ability();
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

    protected virtual void FixedUpdate()
    {
        if (isFlight) Flight();
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
        startBirdPosition = transform.position;
    }

    private void Drag()
    {
        Vector3 dragDirection = startDragPosition - Camera.main.ScreenToWorldPoint(touch.position);
        shotPull = Mathf.Clamp(Mathf.Abs(dragDirection.y) + dragDirection.x, flightSettings.minPull, flightSettings.maxPull);
        shotDirection = dragDirection.normalized;

        transform.position = startBirdPosition - shotDirection * shotPull;
    }

    private void Release()
    {
        //pathDrawer.Clear();
        if (shotPull <= 0) return;
        rb.bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Collider2D>().enabled = true;
        isFlight = true;

        SoundManager.Instance.PlaySound(birdLaugh.GetClip());
    }

    private void Flight()
    {
        rb.velocity = GetNextPointShift(ref shotDirection);
    }

    protected virtual Vector3 GetNextPointShift(ref Vector3 direction)
    {
        direction.y += Time.fixedDeltaTime * -gravityMod;
        return direction * Time.fixedDeltaTime * acceleration * shotPull * 100f;
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDestroyed) return;
        isFlight = false;
        isDestroyed = true;
        rb.gravityScale = 1;

        StartCoroutine("DestroyTimer");
    }

    private IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(3);
        Destroy();
    }

    protected virtual void Destroy()
    {
        OnBirdDestroyed?.Invoke();
        Destroy(gameObject);
    }

    protected abstract void Ability();
}
