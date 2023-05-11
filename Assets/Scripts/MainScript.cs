using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

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
        if (Input.GetKey("h")) {
            Application.Quit(1);
            Debug.Log("h");
        }
    }
}