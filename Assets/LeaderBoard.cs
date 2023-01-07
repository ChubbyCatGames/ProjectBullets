using LootLocker.Requests;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    //id leaderboard de lootloker
    string leaderboardID = "10361";

    //textos para ui ranking
    public TextMeshProUGUI playerNames;
    public TextMeshProUGUI playerScores;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    public IEnumerator SubmitScoreRoutine(int scoreToUpload)
    {
        bool done = false;
        string playerID = PlayerPrefs.GetString("PlayerID");
        //sube la puntuacion del jugador a la tabla de puntuaciones
        LootLockerSDKManager.SubmitScore(playerID, scoreToUpload, leaderboardID, (response) =>
        {
            if (response.success)
            {
                Debug.Log("puntuacion subida");
                done = true;
            }
            else
            {
                Debug.Log("Fallido" + response.Error);
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }
    

    public IEnumerator HighScoresRoutine()
    {
        bool done = false;
        //devuelve lista con diez primeros
        LootLockerSDKManager.GetScoreList(leaderboardID, 10, 0, (response) =>
           {
               if (response.success)
               {
                   string tempPlayerNames = "Names\n";
                   string tempPlayerScores = "Scores\n";

                   LootLockerLeaderboardMember[] members = response.items;

                   for(int i=0; i < members.Length; i++)
                   {
                       //si el jugador ha introducido su nombre se muestra
                       if(members[i].player.name != "")
                       {
                           tempPlayerNames += members[i].rank + ". ";
                           tempPlayerNames += members[i].player.name;
                       }
                       //si no ha puesto nombre se le pone su id de la tabla
                       else
                       {
                           tempPlayerNames += members[i].player.id;
                       }
                       //puntuaciones de los jugadores
                       tempPlayerScores += members[i].score + "\n";
                       //salto de linea
                       tempPlayerNames += "\n";
                   }
                   done = true;
                   playerNames.text = tempPlayerNames;
                   playerScores.text = tempPlayerScores;
               }
               else
               {
                   Debug.Log("Fallido" + response.Error);
                   done = true;
               }
           }
        );
        yield return new WaitWhile(() => done == false);
    }
}
