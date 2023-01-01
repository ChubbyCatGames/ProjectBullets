using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BulletScript : MonoBehaviour
{
    private Vector2 direction;
    [SerializeField] float speed;


    [Range(0,1)]
    [SerializeField] float speedReductionMultiplier;

    private Rigidbody2D rb;
    private CircleCollider2D col;

    //Particles
    [SerializeField] public GameObject slowDownParticles;

    public float Speed { get => speed; set => speed = value; }

    private void Awake() //For testing
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
    }

    private void Start()
    {
        StartCoroutine(TimerToDestroy());
    }

    private void Reset()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();

        gameObject.layer = 10;
        speed = 0.3f;
        speedReductionMultiplier = 0.2f;

        rb.gravityScale = 0;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }


    public void SetParameters(Vector2 direction, float speed)
    {
        this.direction = direction;
        this.speed = speed;
        transform.right = direction;
    }

    public void UpdateVelocity(bool doesSpeedReductionApply = false) //The adjustment variables are the projections of the speed so it is balanced.
    {
        if (doesSpeedReductionApply)
        {
            rb.velocity = new Vector2(direction.x * speed * speedReductionMultiplier, direction.y * speed * speedReductionMultiplier);
        }
        else
        {
            rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
        }

    }

    public virtual void EnterRing() { }

    public virtual void ExitRing() { }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12) //Layer for the speed reduction ring entrance
        {
            EnterRing();
        }

        if (collision.gameObject.layer == 13) //Layer for the speed reduction ring exit
        {
            ExitRing();
        }
    }

    IEnumerator TimerToDestroy()
    {
        yield return new WaitForSeconds(15f);
        Destroy(gameObject);
    }

}
