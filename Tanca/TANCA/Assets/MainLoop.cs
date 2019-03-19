﻿using UnityEngine;
using UnityEngine.UI;

public class MainLoop : MonoBehaviour
{
    [SerializeField] TMPro.TMP_InputField player1field, player2field;
    [SerializeField] Slider s1, s2;
    [SerializeField] Player player1, player2;

    public void EnterResults()
    {
        player1 = null;
        player2 = null;

        foreach (Player player in PlayerMangare.Instance.players)
        {
            if (player.playerName.ToLower() == player1field.text.ToLower())
            {
                player1 = player;
            }
            else if (player.playerName.ToLower() == player2field.text.ToLower())
            {
                player2 = player;
            }
        }

        if (player1 == null || player2 == null)
        {
            Debug.LogError("One or more of these players do not exist");
        }
        else PerformCalculations(player1, player2);
    }

    private void PerformCalculations(Player p1, Player p2)
    {
        EloAlgorithm.Instance.GetNewElo(p1, p2, (int)s1.value, (int)s2.value);
    }
}
