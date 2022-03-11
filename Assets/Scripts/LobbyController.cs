using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// Lobby Controller gameobject contains a pane of start and Quit button
/// Start button loads the LevelSelector
/// Quit button quits the game
/// </summary>
public class LobbyController : MonoBehaviour
{
    //Getting the Play button
    [SerializeField]
    private Button _startBtn;
    //Gettig the Quit Button
    [SerializeField]
    private Button _quitBtn;
    //The Level selector game object to hide and show
    [SerializeField]
    private GameObject _levelSelector;
    private void Awake()
    {
        // adding the listener to the buttons
        _startBtn.onClick.AddListener(LevelSelect);
        _quitBtn.onClick.AddListener(QuitGame);
    }
    //function to load the select level
    private void LevelSelect()
    {
        // levelSelector Gameobject is enabled
        _levelSelector.SetActive(true);
    }
    //function to quit the game
    private void QuitGame()
    {
        //Quitting the Application i.e Game
        Application.Quit();
    }
    

}
