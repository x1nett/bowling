using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private List<Player> players;
    private int index = 0;

    public Player[] playersArr;

    private void Start()
    {
        players = playersArr.ToList();
        SetPlayers();
    }

    private void SetPlayers()
    {
        int len = PlayerPrefs.GetInt("PlayerCount", 0);

        for (int i = 0; i < len; i++)
        {
            players[i].SetName(PlayerPrefs.GetString("Player " + i));
        }
    }

    public void AddScore(int pinCount)
    {
        players[index].AddScore(pinCount);
    }
    
    public void NextPlayer()
    {
        index = (index + 1) % players.Count;
    }
}
