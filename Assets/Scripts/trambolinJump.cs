using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trambolinJump : MonoBehaviour
{   
    //public Animator trambolineAnimator;
    public Rigidbody2D rigidbody;
    public AudioClip trambolinSound;
    public Transform camPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "groundCheck")
        {
            //trambolineAnimator.SetTrigger("touched");
            AudioSource.PlayClipAtPoint(trambolinSound, camPosition.position);
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, 20);
        }
        
    }
}
