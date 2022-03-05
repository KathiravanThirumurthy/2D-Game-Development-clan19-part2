 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField]
    private Image[] _lives;

    void Awake()
    {
        makeSingleton();
    }
    void makeSingleton()
    {
        if(instance !=null)
        {
            Destroy(gameObject);
        }else
        {
            instance = this;
        }
    }
    public void UpdateLives(int livesRemaining)
    {
        Debug.Log(livesRemaining);
        for(int i=0;i<= livesRemaining;i++)
        {
            if(i == livesRemaining)
            {
                _lives[i].enabled = false;
               


            }
        }
    }

    public void restartCurrentScene()
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

    }
}

