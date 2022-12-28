using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class CircleScript : MonoBehaviour
{
    [SerializeField] Transform parent;
    [SerializeField]GameObject player;
    CircleCollider2D collider;


    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<CircleCollider2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (!collider.bounds.Contains(player.transform.position))
        {
            Debug.Log("sali");
            Rigidbody2D rb = player.transform.GetComponent<Rigidbody2D>();
            rb.velocity= Vector3.zero;
            rb.gravityScale = 0;
            Vector3 line =  player.transform.position - collider.bounds.center;
            
            line = line.normalized;
            Vector3 pos = collider.bounds.center + (parent.transform.localScale.x * collider.radius * line);

            player.transform.position = pos;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //print("ey");
        //collision.attachedRigidbody.velocity= Vector3.zero;
        //collision.attachedRigidbody.gravityScale = 0;
    }
}
