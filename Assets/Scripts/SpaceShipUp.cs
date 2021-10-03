using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceShipUp : MonoBehaviour
{
    public Rigidbody2D ShipRb;
    public bool moveTheShip;
    public GameObject player;

    public GameObject miniPlayer;

    private Color playerColor;

    private Color playerTrans;

    private Renderer renderer;

    public GameObject moveButton;

    public Animator transition;

    private float moveInput;

    public float speed = 5;

    public AudioClip death;

    public Transform camPosition;
    // Start is called before the first frame update
    void Start()
    {
        renderer = miniPlayer.GetComponent<Renderer>();
        playerColor = renderer.material.color;
        playerTrans = new Color (255,255,255,0);
    }

    private void OnTriggerEnter2D(Collider2D other) {
         if (other.gameObject.tag == "Player")
            {
                moveTheShip = true;
                renderer.material.color = playerTrans;
                other.transform.parent = this.transform;;
                player.GetComponent<Rigidbody2D>().isKinematic = true;
                camPosition = this.transform;
                
            }

             if (other.gameObject.tag == "Enemy")
            {
            AudioSource.PlayClipAtPoint(death,  camPosition.position);
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            transition.SetTrigger("start");
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
            
                

                
            }
        
    }

    public void LoadNextLevel(){

       StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +1));

    }
        

     IEnumerator LoadLevel (int levelIndex) {

        transition.SetTrigger("start");

        yield return new WaitForSeconds (1);

        SceneManager.LoadScene(levelIndex);
     }
    
    // Update is called once per frame
    void Update()
    {   
        if (moveTheShip == true)
        {
            ShipRb.velocity = new Vector2(0, 7);

            moveInput = SimpleInput.GetAxis("Horizontal");

            ShipRb.velocity = new Vector2 (moveInput * speed, ShipRb.velocity.y);

        }
         
         

    }
}
