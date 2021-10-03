using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisiblePlatform : MonoBehaviour
{
    public float visibilityTime = 2;
    public GameObject platform, platform1, platform2;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        visibilityTime -= Time.deltaTime;

        if (visibilityTime <= 1 )
        {
            platform.SetActive(false);
            platform1.SetActive(false);
            platform2.SetActive(false);
        } else {

            platform.SetActive(true);
            platform1.SetActive(true);
            platform2.SetActive(true);
        }

        if (visibilityTime <=0)
        {
            visibilityTime = 2;
        }
        
    }
    
}
