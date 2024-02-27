using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private TextMeshProUGUI playerNameDisplay;

    private DataManager dm;

    private string playerName;
    
    void Start()
    {
        dm = GameObject.FindObjectOfType<DataManager>();
    }
    
    public void StartButtonClicked() {
        if (playerName !=null) {
            dm.SetPlayer(playerName);
            SceneManager.LoadScene(1);
        }
    }

    public void FieldInput() {
        playerNameDisplay.text = nameInput.text;
        playerName = nameInput.text;
    }

    public void ExitButtonClicked() {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
