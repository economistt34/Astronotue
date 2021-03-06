using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
   public Button [] LevelButtons;
    
    private void Awake(){

        int ReachedLevel = PlayerPrefs.GetInt("Reached Level", 1);
        if (PlayerPrefs.GetInt("Level") >= 2)
        {
            ReachedLevel = PlayerPrefs.GetInt("Level");
        }
        LevelButtons = new Button[transform.childCount];
        for (int i = 0; i < LevelButtons.Length; i++) 
        {
            LevelButtons[i] = transform.GetChild(i).GetComponent<Button>(); 
            LevelButtons[i].GetComponentInChildren<Text>().text = (i +1).ToString();        
            if (i+1 > ReachedLevel)
            {
                    LevelButtons[i].interactable = false;
            }
        }
    }

    public void LoadScene(int Level){

        PlayerPrefs.SetInt("Level", Level);
        Application.LoadLevel("Loading");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
