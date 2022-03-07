using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
///  To load different levels in the game
/// </summary>
[RequireComponent(typeof(Button))]
public class Levelloader : MonoBehaviour
{
    // Initialising Level button 
    private Button _levelButton;
    //levelName should be addded to move for the particular level 
    [SerializeField]
    private string levelName;
   
    void Awake()
    {
        //Getting the component of the Button GameObject
        _levelButton = GetComponent<Button>();
        // adding listener to the level Buttons
        _levelButton.onClick.AddListener(onClick);
    }
    // function to load scene with given string
    private void onClick()
    {
        SceneManager.LoadScene(levelName);
    }
    
}
