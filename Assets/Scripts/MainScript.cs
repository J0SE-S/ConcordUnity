using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;
using UnityEngine.UI;

public class MainScript : NetworkBehaviour {
    public class AccountData {
        public enum Color {
            RED,
            ORANGE,
            YELLOW,
            GREEN,
            LIGHT_BLUE,
            DARK_BLUE,
            PURPLE
        }

        string name;
        Color color;
    }

    AccountData account;

    void Start() {}

    void Update() {
        if (SceneManager.GetActiveScene().name == "MenuScene" && Random.value > 0.95) {
            Button debugButton = GameObject.Find("DebugButton").GetComponent<Button>();
            if (debugButton.interactable) debugButton.interactable = false; else debugButton.interactable = true;
        }
    }

    public void PlayButton() {
        GetComponent<NetworkManager>().StartClient();
    }

    public void SettingsButton() {}

    public void QuitButton() {
        Application.Quit(0);
    }
}