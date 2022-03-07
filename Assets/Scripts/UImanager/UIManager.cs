 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// Here the player status is got and the UI is updates
/// </summary>
public class UIManager : MonoBehaviour
{  
    // getting the instance of UI Manger
    public static UIManager instance;
    // no. of lives of the player
    [SerializeField]
    private Image[] _lives;
    //making Singleton
    void Awake()
    {
        makeSingleton();
    }
    void makeSingleton()
    {
        // checking if instance is not null , we destroy the instance
        if(instance !=null)
        {
            Destroy(gameObject);
        }else
        {
            //if null the this gameObject is treated as instance
            instance = this;
        }
    }
    // getting the Player status and updating the player live UI
    public void UpdateLives(int livesRemaining)
    {

        Debug.Log(livesRemaining);
        //looping through lives of the Payer
        for(int i=0;i<= livesRemaining;i++)
        {
            
            if(i == livesRemaining)
            {
                _lives[i].enabled = false;
               


            }
        }
    }

   /* public void restartCurrentScene()
    {

        StartCoroutine(reloadingCurrentScene());
        //Time.timeScale = 0;


    }
    IEnumerator reloadingCurrentScene()
    {

        yield return new WaitForSeconds(3.0f);
        
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        Time.timeScale = 1;

    }*/
}

