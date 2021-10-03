using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notifications : MonoBehaviour
{

    public GameObject dashNotification;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;

    }
        private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;

    }


}
