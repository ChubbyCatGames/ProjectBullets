using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactMenu : MonoBehaviour
{
    private SoundManager soundManager;
    // Start is called before the first frame update
    [SerializeField] private GameObject contactMenu;
    [SerializeField] private GameObject mainMenu;

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }
    public void LinkTree()
    {
        soundManager.SeleccionAudio(0, 1.0f);
        Application.OpenURL("");
    }

    public void Twitter()
    {

        soundManager.SeleccionAudio(0, 1.0f);
        Application.OpenURL("");
    }



    public void Back()
    {
        soundManager.SeleccionAudio(0, 1.0f);
        contactMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
