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
        float dist = Vector3.Distance(collider.bounds.center, player.transform.position);
        if (dist>(collider.radius*parent.localScale.x))
        {
        player.transform.right = collider.bounds.center - player.transform.position;
            Vector3 line =  player.transform.position - collider.bounds.center;
            
            line = line.normalized;
            Debug.Log(dist);
            Vector3 pos = collider.bounds.center + (parent.transform.localScale.x * (collider.radius) * line);

            Rigidbody2D rb = player.transform.GetComponent<Rigidbody2D>();
            rb.velocity= Vector3.zero;
            rb.gravityScale = 0;
            player.transform.position = pos;

            

        }
    }

}
