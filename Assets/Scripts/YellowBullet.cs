using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBullet : BulletScript
{
    [SerializeField] private GameObject bulletDivision;
    [SerializeField] private Transform divisionDirection1, divisionDirection2;

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

        GameObject bullet1 = Instantiate(bulletDivision);
        GameObject bullet2 = Instantiate(bulletDivision);
        bullet1.transform.parent = GameObject.Find("Game").transform;
        bullet2.transform.parent = GameObject.Find("Game").transform;

        //bullet1
        bullet1.transform.position = transform.position;
        Vector3 destiny = divisionDirection1.position;
        Vector2 directionVector = new Vector2(destiny.x, destiny.y) - new Vector2(bullet1.transform.position.x, bullet1.transform.position.y);
        bullet1.GetComponent<BulletScript>().SetParameters(directionVector, Speed*50);

        //bullet2
        bullet2.transform.position = transform.position;
        destiny = divisionDirection2.position;
        directionVector = new Vector2(destiny.x, destiny.y) - new Vector2(bullet2.transform.position.x, bullet2.transform.position.y);
        bullet2.GetComponent<BulletScript>().SetParameters(directionVector, Speed*50);

        //Velocities
        bullet1.GetComponent<BulletScript>().UpdateVelocity(false);
        bullet2.GetComponent<BulletScript>().UpdateVelocity(false);

        StartCoroutine(UpdateSpeedAfter(bullet1, bullet2));

        //Destroy
        Destroy(gameObject);
    }

    IEnumerator UpdateSpeedAfter(GameObject b1, GameObject b2)
    {
        yield return new WaitForSeconds(0.5f);
        b1.GetComponent<BulletScript>().UpdateVelocity(false);
        b2.GetComponent<BulletScript>().UpdateVelocity(false);
    }
}
