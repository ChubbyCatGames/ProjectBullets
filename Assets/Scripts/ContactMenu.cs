using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject contactMenu;
    [SerializeField] private GameObject mainMenu;


    public void LinkTree()
    {
        Application.OpenURL("");
    }

    public void Twitter()
    {


        Application.OpenURL("");
    }



    public void Back()
    {
        contactMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
