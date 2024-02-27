using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public int highestScore;

    public Player currentPlayer;

    public List<Player> highscores = new List<Player>();

    private void Awake() {

        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        LoadList();
    }

    public string GetPlayerName() {
        return currentPlayer.GetName();
    }

    [System.Serializable]
    class SaveData {
        public List<Player> highscores;
    }   
    
    public void SaveList() {
        SaveData data = new SaveData();
        data.highscores = highscores;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadList() {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highscores = data.highscores;
        } else {
            SaveList();
        }
            
    }

    public bool CheckPlayerName(string input) {
        foreach (Player temp in highscores) {
            if (input == temp.GetName()) {
                return true;
            }
        }
        return false;
    }
    
    public Player SetPlayer(string input) {
        if (CheckPlayerName(input)) {
            foreach (Player temp in highscores) {
                if (input == temp.GetName()) {
                    currentPlayer = temp;
                    return temp;
                }
            }
        }       
        currentPlayer = new Player(input, 0);
        highscores.Add(currentPlayer);
        return new Player(input, 0);
    }
    

    public int GetHighestScore(Player input) {
        if (CheckPlayerName(input.GetName())) {
            foreach (Player temp in highscores) {
                if (input.GetName() == temp.GetName()) {
                    highestScore = temp.GetScore();
                    return highestScore;
                }
            }
        }
            return highestScore = 0;
    }

    public void CheckScore(string input, int score) {
        if (CheckPlayerName(input)) {
            foreach (Player temp in highscores) {
                if (temp.GetName() == input && score > temp.GetScore()) {
                    currentPlayer.SetScore(score);
                    return;
                }
            }
        }
    }
        
}
