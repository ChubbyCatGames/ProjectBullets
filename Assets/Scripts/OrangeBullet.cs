using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeBullet : BulletScript
{
    [SerializeField] private CircleCollider2D damageCircle;
    [SerializeField] private GameObject particleExplosionPrefab;

    

    private Collider2D explosionRing;

    bool alreadyExplode = false;

    override public void Awake()
    {
        base.Awake();
        explosionRing = GameObject.Find("ExplosionRing").GetComponent<Collider2D>();


        damageCircle.enabled = false;

        alreadyExplode = false;

    }


    private void Explode()
    {
        if (alreadyExplode) return;
        //Particles
        GameObject particles = GameObject.Instantiate(particleExplosionPrefab);
        particles.transform.position = gameObject.transform.position;
        particles.GetComponent<ParticleSystem>().Play();
        soundManager.SeleccionAudio(6, 1.5f);

        StartCoroutine(ExplosionDamage());
    }

    public override void EnterRing()
    {
        base.EnterRing();

        //Particles
        GameObject particles = GameObject.Instantiate(slowDownParticles);
        particles.transform.position = gameObject.transform.position;
        particles.GetComponent<ParticleSystem>().Play();

        //Velocity
        UpdateVelocity(true);
    }

    public override void ExitRing()
    {
        base.ExitRing();

        UpdateVelocity(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject == explosionRing.gameObject)
        {
            Explode();
        }
    }

    IEnumerator ExplosionDamage()
    {
        alreadyExplode = true;

        DisableSpriteRenderers();

        damageCircle.enabled = true;

        yield return new WaitForSeconds(0.3f);

        damageCircle.enabled = false;

        Destroy(gameObject);
    }

    private void DisableSpriteRenderers()
    {
        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();

        foreach(SpriteRenderer sr in sprites)
        {
            sr.enabled = false;
        }
    }
}
