using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class GameMaster : MonoBehaviour
{
    private float deviceWidth;
    [SerializeField] GameObject circle;


    // Start is called before the first frame update
    void Start()
    {
        deviceWidth= Screen.width;
        float aspect = (float)Screen.width / Screen.height;

        float worldHeight = Camera.main.orthographicSize * 2;

        float worldWidth = worldHeight * aspect;

        circle.transform.localScale= new Vector3(worldWidth*0.9f,worldWidth*0.9f,0);
    }

    // Update is called once per frame
    void Update()
    {
        float aspect = (float)Screen.width / Screen.height;

        float worldHeight = Camera.main.orthographicSize * 2;

        float worldWidth = worldHeight * aspect;

        circle.transform.localScale = new Vector3(worldWidth * 0.9f, worldWidth * 0.9f, 0);
    }
}
