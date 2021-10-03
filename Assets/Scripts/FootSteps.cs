using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{   
    public AudioClip footstep;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayFootSteps(){

        AudioSource.PlayClipAtPoint(footstep, transform.position, 2f);
    }
}
