using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerScript : MonoBehaviour
{

    Vector2 vec = new Vector2();
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartLaunch(InputAction.CallbackContext ctx)
    {

        
            vec = ctx.ReadValue<Vector2>();
            print(ctx.phase);
            Vector2 world = Camera.main.ScreenToWorldPoint(vec);
            MovePlayer(world);
        

    }

    public void MovePlayer(Vector2 pos)
    {
        Vector2 dif= pos - rb.position;
        rb.AddForce(dif*100);
    }


}
