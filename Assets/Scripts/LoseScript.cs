using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScript : MonoBehaviour


{
    private SoundManager soundManager;

    [SerializeField] private GameObject rankingButton;

    [SerializeField] private GameObject endGamePanel;

    [SerializeField] private GameObject rankingMenu;

    [SerializeField] private GameObject mainMenu;

    [SerializeField] private GameObject game;

    [SerializeField] private GameObject points;

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }
    public void Ranking()
    {
        soundManager.SeleccionAudio(0, 1.0f);
        //Time.timeScale = 0f;
        endGamePanel.SetActive(false);
        rankingMenu.SetActive(true);
    }

    public void Home()
    {
        soundManager.SeleccionAudio(0, 1.0f);
        //Time.timeScale = 0f;
        mainMenu.SetActive(true);
        rankingMenu.SetActive(false);
    }
}
