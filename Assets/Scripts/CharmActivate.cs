using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharmActivate : MonoBehaviour
{

    public int CharmCollected = 0;
    public GameObject dashNotification;
    public AudioClip dashCollectedSound;

    public Transform camPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    
    {
       CharmCollected = 1;
       Destroy(gameObject);
       dashNotification.GetComponent<SpriteRenderer>().enabled = true;  
       AudioSource.PlayClipAtPoint(dashCollectedSound, camPosition.position);

    }

     private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;

    }


}
