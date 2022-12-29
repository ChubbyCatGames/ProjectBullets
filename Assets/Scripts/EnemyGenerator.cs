using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    private float waitTimer;
    private float increaseDifficultyTimer;

    [SerializeField] private GameObject bulletPrefab;

    private GameObject player;

    private void Awake()
    {
        waitTimer = 1.5f;
        increaseDifficultyTimer = 2;

        Physics2D.IgnoreLayerCollision(10, 10);

        player = GameObject.Find("Player");

        StartCoroutine(EnemyGeneratorStart());
        StartCoroutine(TimerIncrease());
        StartCoroutine(TimerAttackPlayer());
    }


    private Vector2 GetRandomSpawnPoint()
    {
        Vector2 spawn;

        int random = Random.Range(0, 4); //4 possible numbers

        switch (random)
        {
            case 0: //Top
                spawn = new Vector2(Random.Range(-1f, 1f), Random.Range(1.2f, 4f));
                break;
            case 1: //Bottom
                spawn = new Vector2(Random.Range(-1f, 1f), Random.Range(-4f, -1.2f));
                break;
            case 2: //Right
                spawn = new Vector2(Random.Range(1f, 4f), Random.Range(-1f, 1f));
                break;
            case 3: //Left
                spawn = new Vector2(Random.Range(-4f, -1f), Random.Range(-1f, 1f));
                break;
            default:
                spawn = new Vector2(Random.Range(-1f, 1f), Random.Range(1.2f, 2f));
                break;
        }
        return spawn;
    }

    private Vector2 GenerateRandomDestiny()
    {
        Vector2 destiny = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
        bool checkInsideCircle = destiny.magnitude <= 0.5;

        int controlCounter = 0;

        while (!checkInsideCircle) 
        {
            destiny = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
            controlCounter++;

            if (controlCounter > 20)
            {
                break;
            }
        }
        return destiny;
    }

    private void GenerateEnemies(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GenerateNewEnemy(GetRandomSpawnPoint(), GenerateRandomDestiny());
        }
    }

    private void GenerateNewEnemy(Vector2 position, Vector2 destination)
    {
        GameObject generatedBullet = Instantiate(bulletPrefab);
        generatedBullet.transform.parent = GameObject.Find("Game").transform;

        generatedBullet.transform.localPosition = position;

        if (generatedBullet.TryGetComponent<BulletScript>(out BulletScript bullet))
        {
            Vector2 directionVector = destination - new Vector2(generatedBullet.transform.position.x, generatedBullet.transform.position.y);

            bullet.SetParameters(directionVector, bulletPrefab.GetComponent<BulletScript>().Speed);

            bullet.UpdateVelocity(false); //The projections of the movement
        }
    }

    IEnumerator EnemyGeneratorStart()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTimer);

            GenerateEnemies(Random.Range(1, 2));//Can be increased for a higher difficulty
        }
    }

    IEnumerator TimerIncrease()
    {
        while (true)
        {
            yield return new WaitForSeconds(increaseDifficultyTimer);
            waitTimer -= waitTimer/30;
            if (waitTimer <= 0.3f)
            {
                waitTimer = 0.3f;
            }
        }
    }

    IEnumerator TimerAttackPlayer()//This prevents the player to be in the same spot for a long time
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            GenerateNewEnemy(GetRandomSpawnPoint(), (Vector2) player.transform.position);
        }
    }
}
