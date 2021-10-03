using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{   
    public Animator transition;
    public float transitionTime = 1;
    public Animator animator;
   
   
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel(){

       StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +1));
        
    }

    IEnumerator LoadLevel (int levelIndex) {

        transition.SetTrigger("start");

        yield return new WaitForSeconds (transitionTime);

        SceneManager.LoadScene(levelIndex);



    }
}
