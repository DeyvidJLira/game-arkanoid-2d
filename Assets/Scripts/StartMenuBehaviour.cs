using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuBehaviour : MonoBehaviour
{
    public void playGame() {
        SceneManager.LoadScene("Scenes/MainGame");
    }

    public void credits() {

    }
}
