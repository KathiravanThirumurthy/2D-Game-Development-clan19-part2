using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
/// <summary>
/// When the Level complete it will load the next level 
/// </summary>

public class LevelController : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D target)
    {
        // if the player collides with Ground with tag "Platform"
       if(target.gameObject.GetComponent<PlayerController>())
        {
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.buildIndex+1);
        }

    }

    
}
