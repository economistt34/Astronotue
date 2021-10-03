using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevelManager : MonoBehaviour
{
    public int buildIndex = 0;
    
    private void Start(){

        buildIndex = SceneManager.GetActiveScene().buildIndex;
       Text levelText = GameObject.Find("LevelText").GetComponent<Text>();
        levelText.text = "Level_" +buildIndex.ToString();
    }

    public void NextLevel(){
        
        int saveIndex = PlayerPrefs.GetInt("SaveIndex");
        if(buildIndex > saveIndex)
        {
        PlayerPrefs.SetInt("SaveIndex", buildIndex);
        }
        if (buildIndex == 100)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(buildIndex +1);
        }
    }
}
