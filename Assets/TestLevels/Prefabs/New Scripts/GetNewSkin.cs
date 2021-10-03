using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNewSkin : MonoBehaviour
{
    [SerializeField] private SkinManager skinManager;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = skinManager.GetSelectedSkin().sprite;
    }

    // Update is called once per frame
   
}
