using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField] GameObject coinPrefab;
    private float deviceWidth;
    private float timer;
    float worldWidth;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;

        deviceWidth = Screen.width;
        float aspect = (float)Screen.width / Screen.height;

        float worldHeight = Camera.main.orthographicSize * 2;

        worldWidth = worldHeight * aspect;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 5)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            GameObject coin= Instantiate(coinPrefab);
            coin.transform.position = Random.insideUnitCircle*worldWidth*0.3f;
        }
    }
}
