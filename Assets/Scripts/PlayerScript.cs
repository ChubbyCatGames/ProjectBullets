using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerScript : MonoBehaviour
{
    private SoundManager soundManager;

    [SerializeField] GameMaster gameMaster;

    [SerializeField] private GameObject deathParticlesPrefab;
    [SerializeField] private GameObject collectCoinParticlesPrefab;

    Vector2 vec = new Vector2();
    Rigidbody2D rb;
    float jumpSpeed = 1000;

    public bool canJump;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        soundManager = FindObjectOfType<SoundManager>();
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
        soundManager.SeleccionAudio(1, 1f);
    }

    private void Die()
    {
        //Particles
        soundManager.SeleccionAudio(2, 2f);

        GameObject particles = GameObject.Instantiate(deathParticlesPrefab);
        particles.transform.position = gameObject.transform.position;
        particles.GetComponent<ParticleSystem>().Play();

        gameMaster.EndGame();

        //Destroy player, points and pause button
        gameObject.SetActive(false);
    }
    private void WinPoints()
    {
        //Debug.Log("coinCollected");
        gameMaster.CoinCollected();
        soundManager.SeleccionAudio(7, 2f);

        //Particles
        GameObject particles = GameObject.Instantiate(collectCoinParticlesPrefab);
        particles.GetComponent<ParticleSystem>().Play();
        particles.transform.parent = gameObject.transform;
        particles.transform.localPosition = Vector2.zero;

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 10)//If detect enemy collision
        {
            Die();
        }
        if(collision.gameObject.layer == 11)
        {
            WinPoints();
            Destroy(collision.gameObject);
        }
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 10)
        {
            Die();
        }
        if (collision.gameObject.layer == 11)
        {
            WinPoints();
            Destroy(collision.gameObject);
        }
    }

}
