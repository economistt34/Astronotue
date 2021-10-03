using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleJumpCharm : MonoBehaviour
{
    // Start is called before the first frame update
 
    public int ifDoubleCharmCollected ;
    public AudioClip Collected;
    

   private void OnTriggerEnter2D(Collider2D collision)
    {
       ifDoubleCharmCollected= 1;
       Destroy(gameObject);
       AudioSource.PlayClipAtPoint(Collected, transform.position);

    }
}
