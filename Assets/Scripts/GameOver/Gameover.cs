using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    [SerializeField]
    private Button _btnRestart;
    [SerializeField]
    private Button _btnQuit;
    private void Awake()
    {
        _btnRestart.onClick.AddListener(ReloadLevel);
        _btnQuit.onClick.AddListener(QuitGame);
    }
    // Update is called once per frame

    public void PlayerDied()
    {
       gameObject.SetActive(true);
    }
    private void ReloadLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
    private void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
        
    }
}
