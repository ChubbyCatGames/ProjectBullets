using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScript : MonoBehaviour
{
    [SerializeField] private GameObject rankingButton;

    [SerializeField] private GameObject endGamePanel;

    [SerializeField] private GameObject rankingMenu;

    [SerializeField] private GameObject mainMenu;

    [SerializeField] private GameObject game;

    [SerializeField] private GameObject points;

    public void Ranking()
    {
        //Time.timeScale = 0f;
        endGamePanel.SetActive(false);
        rankingMenu.SetActive(true);
    }

    public void Home()
    {
        //Time.timeScale = 0f;
        mainMenu.SetActive(true);
        rankingMenu.SetActive(false);
    }
}
