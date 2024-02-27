using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Player
{
    public string playerName;
    public int score;

    public Player(string name, int points) {
        playerName = name;
        score = points;
    }

    public string GetName() {
        return playerName;
    }

    public int GetScore() {
        return score;
    }

    public void SetScore(int points) {
        score = points;
    }
}
