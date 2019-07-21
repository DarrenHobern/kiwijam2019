using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public static MenuScript Instance;
    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Debug.LogWarning("Only one Game Controller can exist");
            Destroy(gameObject);
        }
    }
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
