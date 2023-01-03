using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject pauseButton;
    private SoundManager soundManager;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject mainMenu;
    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }
    public void Pause()
    {
        soundManager.SeleccionAudio(0, 1.0f);
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        soundManager.SeleccionAudio(0, 1.0f);
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void Replay()
    {
        soundManager.SeleccionAudio(0, 1.0f);
        //Time.timeScale = 1f;
        pauseButton.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }



    public void ExitGame()
    {
        soundManager.SeleccionAudio(0, 1.0f);
        Debug.Log("Ta luego");
    
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}
