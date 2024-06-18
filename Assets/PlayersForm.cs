using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayersForm : MonoBehaviour
{
    public TMP_InputField[] playerNames;

    private void SavePlayersName()
    {
        for (int i = 0; i < playerNames.Length; i++)
        {
            PlayerPrefs.SetString("Player " + i, playerNames[i].text);
        }
        PlayerPrefs.SetInt("PlayerCount", playerNames.Length);
        PlayerPrefs.Save();
    }

    public void PlayGame()
    {
        SavePlayersName();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
