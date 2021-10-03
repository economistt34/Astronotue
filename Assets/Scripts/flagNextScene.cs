using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class flagNextScene : MonoBehaviour
{    
 public int buildIndex = 0;
public Animator transition, animator;
public float transitionTime = 1;
public AudioClip winSound;
 [SerializeField] private GameController gameController;
    
    private void Start(){

        buildIndex = SceneManager.GetActiveScene().buildIndex;
        
        //gameController.DeleteSkins();
    //    Text levelText = GameObject.Find("LevelText").GetComponent<Text>();
    //     levelText.text = "Level_" +buildIndex.ToString();
    }

    public void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "Player"){

        // PlayerPrefs.SetInt("ReachedLevel", PlayerPrefs.GetInt("ReachedLevel") +1);
        // Application.LoadLevel("level");
        int saveIndex = PlayerPrefs.GetInt("SaveIndex");
        if(buildIndex > saveIndex)
        {
        PlayerPrefs.SetInt("SaveIndex", buildIndex -1);
        gameController.AddCoins();
        gameController.OnBackButtonPressed();
        
        }
        if (buildIndex == 100)
        {
            SceneManager.LoadScene(0);
        }
        else
        {   AudioSource.PlayClipAtPoint(winSound,  transform.position);
            transition.SetTrigger("start");
            animator.SetTrigger("finish");
            //SceneManager.LoadScene(buildIndex +1);
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +1));
            //gameController.AddCoins();
            gameController.OnBackButtonPressed();
            
        }
    }
    }
    
    //  private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    //     SceneManager.LoadScene(currentSceneIndex +1);
    // }
        IEnumerator LoadLevel (int levelIndex) {

        //transition.SetTrigger("start");

        yield return new WaitForSeconds (transitionTime);

        SceneManager.LoadScene(levelIndex);

    }
}
