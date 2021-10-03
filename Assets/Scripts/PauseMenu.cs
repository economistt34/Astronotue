using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public bool ifMenuButtonPressed = false;
    


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || ifMenuButtonPressed == true)
        {
            if (gameIsPaused)
            {
                Resume();

            } else{

                Pause();
            }
        }
        
    }

    void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        ifMenuButtonPressed = false;

    }

    public void Pause(){

            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            gameIsPaused = true;
            ifMenuButtonPressed = false;
    }

    public void MenuButton(){

        ifMenuButtonPressed = true;
    }

    public void QuitApp(){

        Application.Quit();
    }

    public void MenuScreen(){

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(0); 

        Time.timeScale = 1f;
    }
    
}
