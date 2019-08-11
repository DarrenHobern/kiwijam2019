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
        Screen.SetResolution(1280, 720, true);
    }
    public void ToStartGame() {
        StartCoroutine(LoadScene("StartGame"));
    }

    public void ToEndOver() {
        StartCoroutine(LoadScene("Gameover"));
    }

    public void ToGame() {
        StartCoroutine(LoadScene("Game"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator LoadScene(string scene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);
        while(!asyncLoad.isDone) {
            yield return null;
        }
    }
}
