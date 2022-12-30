using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using TMPro;

public class GameMaster : MonoBehaviour
{
    private float deviceWidth;
    [SerializeField] GameObject circle;
    [SerializeField] GameObject endGamePanel;
    private float points;
    [SerializeField] TextMeshProUGUI textPoints;

    // Start is called before the first frame update
    void Start()
    {
        deviceWidth= Screen.width;
        float aspect = (float)Screen.width / Screen.height;

        float worldHeight = Camera.main.orthographicSize * 2;

        float worldWidth = worldHeight * aspect;

        circle.transform.localScale= new Vector3(worldWidth*0.8f,worldWidth*0.8f,0);

        points= 0;
    }

    // Update is called once per frame
    void Update()
    {
        float aspect = (float)Screen.width / Screen.height;

        float worldHeight = Camera.main.orthographicSize * 2;

        float worldWidth = worldHeight * aspect;

        circle.transform.localScale = new Vector3(worldWidth * 0.8f, worldWidth * 0.8f, 0);

        points += Time.deltaTime;

        textPoints.text = Mathf.FloorToInt(points).ToString();
    }

    public void EndGame()
    {
        StartCoroutine(WaitForDeathAnimationAndEndGame());
    }

    IEnumerator WaitForDeathAnimationAndEndGame()
    {
        yield return new WaitForSeconds(3f);
        Time.timeScale = 0f;
        endGamePanel.SetActive(true);
        TextMeshProUGUI final = GameObject.Find("FinalScore").GetComponent<TextMeshProUGUI>();
        final.text = "Your Score: " + textPoints.text.ToString();
    }
}
