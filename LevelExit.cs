using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    public GameSession gameSessionScript;

    void OnTriggerEnter2D(Collider2D other) 
    {
            StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings && gameSessionScript.score >=2)
        {
            nextSceneIndex = 0;
        }
        if (gameSessionScript.score >= 2)
        {
          SceneManager.LoadScene(nextSceneIndex);
        }
        
        
    }

}

//FindObjectOfType<LevelExit>().turnTrue();