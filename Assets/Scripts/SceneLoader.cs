using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoader : MonoBehaviour
{   
    // public TextMeshProUGUI text;
    public Animator transition;
    public float transitionTime = 1;

    public AudioClip death;

    public Transform camPosition;
    
    
    


    // private void Start() {
    //     int levelText =int.Parse(text.text);
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))

        {
            AudioSource.PlayClipAtPoint(death,  camPosition.position);
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            transition.SetTrigger("start");
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
            
        }
        
    }

     public void LoadNextScene()
    {  
        //   int levelText =int.Parse(text.text);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void LoadStartMenu()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(1);
    }

    public void LevelNumberLoad(){

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;        
        SceneManager.LoadScene(1);

    }
    public void QuitGame()
    {
        Application.Quit();

    }

     public void SkinShop()
    {
        SceneManager.LoadScene("SkinShop");

    }

     IEnumerator LoadLevel (int levelIndex) {

        //transition.SetTrigger("start");

        yield return new WaitForSeconds (transitionTime);

        SceneManager.LoadScene(levelIndex);

    }
}
