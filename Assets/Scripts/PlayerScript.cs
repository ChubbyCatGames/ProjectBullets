using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerScript : MonoBehaviour
{

    [SerializeField] GameMaster gameMaster;

    [SerializeField] private GameObject deathParticlesPrefab;

    Vector2 vec = new Vector2();
    Rigidbody2D rb;
    float jumpSpeed = 1000;

    public bool canJump;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnStartLaunch(InputAction.CallbackContext ctx)
    {
        vec = ctx.ReadValue<Vector2>();
        Vector2 world = Camera.main.ScreenToWorldPoint(vec);
        if (canJump)
        {
            canJump = false;
            MovePlayer(world);
        }

    }

    public void MovePlayer(Vector2 pos)
    {
        Vector2 dif = pos - rb.position;

        rb.AddForce(dif.normalized * jumpSpeed);
        
    }

    private void Die()
    {
        //Particles
        GameObject particles = GameObject.Instantiate(deathParticlesPrefab);
        particles.transform.position = gameObject.transform.position;
        particles.GetComponent<ParticleSystem>().Play();

        gameMaster.EndGame();

        //Destroy player
        gameObject.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 10)//If detect enemy collision
        {
            Die();
        }
    }

}
