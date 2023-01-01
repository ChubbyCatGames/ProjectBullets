using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBullet : BulletScript
{
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
}
