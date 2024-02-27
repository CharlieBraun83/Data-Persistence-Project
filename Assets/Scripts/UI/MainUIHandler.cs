using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highscoreText;
    private DataManager dm;   

    private void Start() {
        dm = GameObject.Find("DataManager").GetComponent<DataManager>();
    }

    public void RefreshUI() {
        highscoreText.text = "Your highest score : " + dm.currentPlayer.GetName() + " " + dm.GetHighestScore(dm.currentPlayer);
    }
}
