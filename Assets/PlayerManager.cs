using LootLocker.Requests;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public TMP_InputField playerNameInput;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoginRoutine());
    }

    public void SetPlayerName()
    {
        LootLockerSDKManager.SetPlayerName(playerNameInput.text, (response) =>
        {
            if (response.success)
            {
                Debug.Log("nombre puesto");
            }
            else
            {
                Debug.Log("nombre NO puesto" + response.Error);
            }
        });
    }

    IEnumerator LoginRoutine()
    {
        bool done = false;
        //inicia sesion del jugador
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("Jugador logueado");
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                done = true;
            }
            else
            {
                Debug.Log("No se pudo iniciar sesion");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
