using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        print("ey");
        collision.attachedRigidbody.velocity= Vector3.zero;
        collision.attachedRigidbody.gravityScale = 0;
    }
}
