using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    private SoundManager soundManager;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject rankingMenu;
    [SerializeField] private GameObject contactMenu;

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();

        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlayMenuMusic();
    }
    public void NewGame()
    {
        soundManager.SeleccionAudio(0, 1.0f);
        Time.timeScale = 1f;
        mainMenu.SetActive(false);
        pauseButton.SetActive(true);

        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlayGameMusic();
    }

    public void Leaderboard()
    {

        soundManager.SeleccionAudio(0, 1.0f);
        rankingMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void Contact()
    {
        soundManager.SeleccionAudio(0, 1.0f);
        mainMenu.SetActive(false);
        contactMenu.SetActive(true);
        
    }



    public void ExitGame()
    {
        soundManager.SeleccionAudio(0, 1.0f);
        Debug.Log("Ta luego");

        Application.Quit();
    }
}
