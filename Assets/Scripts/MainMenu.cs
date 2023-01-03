using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{



    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject rankingMenu;
    [SerializeField] private GameObject contactMenu;


    public void NewGame()
    {
        Time.timeScale = 1f;
        mainMenu.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void Leaderboard()
    {
        
        
        rankingMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void Contact()
    {
        mainMenu.SetActive(false);
        contactMenu.SetActive(true);
        
    }



    public void ExitGame()
    {
        Debug.Log("Ta luego");

        Application.Quit();
    }
}
