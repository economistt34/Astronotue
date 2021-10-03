using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkIfGrounded : MonoBehaviour
{
    public playerWalking playerScript;
    //public GameObject walkParticle;

    //public AudioClip landing;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ground" || other.tag == "MovingPlatform"  || other.tag == "circle" )
        {
            playerScript.grounded = true;
            //AudioSource.PlayClipAtPoint(landing,  transform.position);
            // for(int i = 0;i <= 30;i++)
            // {
            //     Instantiate(walkParticle,new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f),Quaternion.identity);
            // }
        }

         if (other.tag == "circle")
        {
            playerScript.grounded = true;
            

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "ground" || other.tag == "MovingPlatform" )
        {
            playerScript.grounded = false;
        }
         

    }
}