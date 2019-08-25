using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuBehaviour : MonoBehaviour
{

    public GameObject startPanel;
    public GameObject creditsPanel;

    public void playGame() {
        SceneManager.LoadScene("Scenes/MainGame");
    }

    public void credits() {
        startPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void startMenu() {
        creditsPanel.SetActive(false);
        startPanel.SetActive(true);
    }
}
