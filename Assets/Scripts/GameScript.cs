using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour {
    MainScript mainScript;

    void Awake() {
        mainScript = GameObject.Find("Directional Light").GetComponent<MainScript>();
    }

    public void Quit() {
        Application.Quit(0);
    }
}