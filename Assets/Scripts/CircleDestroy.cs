using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CircleDestroy : MonoBehaviour
{

    public Animator rubyAnimator;
    public AudioClip bubleSound;
    public Transform camPosition;
    public TextMeshProUGUI diamondMessage;
    public bool rubycollected;
    public float rubyWaitTime = 0.1f;
    //public PauseMenu pauseMenu;

    private void Start() {

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 2)
        {
            diamondMessage.gameObject.SetActive(true);
        }
        
        
    }

    public void OnTriggerEnter2D(Collider2D other) {
        
        rubyAnimator.SetTrigger("touch");
        AudioSource.PlayClipAtPoint(bubleSound, camPosition.position);
        //gameObject.GetComponent<SpriteRenderer>().enabled = false;
        rubycollected = true;
        Time.timeScale = 0.4f;

        
        
        //Time.timeScale = 0.6f;
    }

    public void Update() {

        if (rubycollected == true)
        {
            rubyWaitTime -= Time.deltaTime;
        }

        if (rubyWaitTime <= 0)
        {
            Time.timeScale = 1f;
            rubycollected = false;
            rubyWaitTime = 0.1f;
        }

        

        
    }
    
    
}
