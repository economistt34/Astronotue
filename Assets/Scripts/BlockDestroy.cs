using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroy : MonoBehaviour
{   
    public AudioClip brokenPlatform;


 
    // Start is called before the first frame update
   private void OnTriggerEnter2D(Collider2D collision){

            
            Destroy(gameObject , 0.2f);
            AudioSource.PlayClipAtPoint(brokenPlatform,  transform.position);
           
        
}
}