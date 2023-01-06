using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField] GameObject coinPrefab;
    [SerializeField] private GameObject generateBulletCoinParticlesPrefab;

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
        if (timer < 3)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            GenerateCoin();
        }
    }

    public void GenerateCoin()
    {
        GameObject coin = Instantiate(coinPrefab);
        coin.transform.position = Random.insideUnitCircle * worldWidth * 0.3f;
    }

    public void GenerateCoinByBullet()
    {
        StartCoroutine(GenerateCoinByBulletCoroutine());
    }

    IEnumerator GenerateCoinByBulletCoroutine()
    {
        yield return new WaitForSeconds(0.5f);

        GameObject coin = Instantiate(coinPrefab);
        coin.transform.position = Random.insideUnitCircle * worldWidth * 0.3f;

        //Particles
        GameObject particles = GameObject.Instantiate(generateBulletCoinParticlesPrefab);
        particles.transform.position = coin.transform.position;
        particles.GetComponent<ParticleSystem>().Play();
    }
}
