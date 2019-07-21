using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void ToStartGame() {
        SceneManager.LoadScene("StartGame");
    }

    public void ToEndOver() {
        SceneManager.LoadScene("Gameover");
    }

    public void ToGame() {
        SceneManager.LoadScene("Game");
    }
}
