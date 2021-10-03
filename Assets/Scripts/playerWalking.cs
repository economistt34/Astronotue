using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerWalking : MonoBehaviour
{
    //[SerializeField] private SkinManager skinManager;
    public float speed;
    public float jumpSpeed , playerDeadTime;
    private Rigidbody2D rigidbody;
    private float moveInput;
    private SpriteRenderer sprRend;
    public Animator animator;
    public GameObject walkParticle;
    public bool grounded;
    public float jumpTime;
    private float jumpTimeCounter;
    private bool isJumping;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    public int direction;
    public GameObject dashParticle;
    public TrailRenderer trailRenderer;
    private GameObject cam;
    private Animator camAnim;
    public GameObject dashCharm;
    public GameObject  duobleJumpCharm;
    public int ifCharmCollected = 0;
    public int jumpCount = 1;
    public int dashCount;
    public int ifDoubleCharmCollected ;
    public int playerHealth = 100;
    public int playerDemage = 20;
    //public GameObject playerParticle;
    public int lastDirection;
    public bool ifDashPressed = false;
    private float keyboadInput;
    public AudioClip dash, jump, death;
    public GameObject dashButton;  
    public GameObject moveButton;
    public Animator transition;
    public float transitionTime = 1;
    public Transform camPosition;
    public float hangTime = 0.2f;
    private float hangCounter;
    public GameObject gravityCharm;
    public GameObject player;
    public bool reversePlayer = false;
        

    void Start()
    {   hangTime = 0.2f;     
        int resolution = Screen.currentResolution.refreshRate;
        Application.targetFrameRate = resolution;
        //runSound = GetComponent<AudioSource>();
         //player.GetComponent<SpriteRenderer>().enabled = true;
        //player.GetComponent<SpriteRenderer>().sprite = skinManager.GetSelectedSkin().sprite;
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        camAnim = cam.GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.cyan, 0.0f), new GradientColorKey(Color.white, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(1, 0.0f), new GradientAlphaKey(0, 1.0f) });
        trailRenderer.colorGradient = gradient;        
    }

    private void OnTriggerEnter2D(Collider2D collision){

        if (collision.gameObject == dashCharm)
        {
            ifCharmCollected = 1;
            Destroy(dashCharm);           
        }
         if (collision.gameObject == duobleJumpCharm)
        {
            ifDoubleCharmCollected = 1;           
        }

        if (collision.gameObject == gravityCharm)
        {   
            Destroy(collision.gameObject);
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpSpeed * 10);            
            rigidbody.gravityScale = -3.5f;
            //Jump();
            player.transform.Rotate(180,0,0);            
            reversePlayer = true;
            camPosition.transform.position = new Vector2 (camPosition.position.x,-6); 
        }
            

        // if (collision.gameObject == gravityCharm && reversePlayer == true)
        //     {
        //     rigidbody.gravityScale = 3.5f;
        //     Jump();
        //     player.transform.Rotate(180,0,0);
        //     Destroy(collision.gameObject);
        //     reversePlayer = false;
        //     camPosition.transform.position = new Vector2 (2,4); 
        //     }
            
        

         if (collision.gameObject.tag == "Enemy")
        {                
            playerHealth -= playerDemage;
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            moveButton.gameObject.SetActive(false);
            dashButton.gameObject.SetActive(false);
            rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;            
            Destroy(collision.gameObject);
            Physics2D.IgnoreCollision(GetComponent<Collider2D>() , collision.GetComponent<Collider2D>());
            StartCoroutine(Death(SceneManager.GetActiveScene().buildIndex));
        }

        if (collision.gameObject.tag == "Laser" && dashCount == 1)
        {               
            playerHealth -= playerDemage;
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            moveButton.gameObject.SetActive(false);
            dashButton.gameObject.SetActive(false);
             Destroy(collision.gameObject);
            StartCoroutine(Death(SceneManager.GetActiveScene().buildIndex ));
        }        
         if (collision.gameObject.CompareTag("MovingPlatform"))
        {
           Debug.Log("MovingPlatform detected");
           this.transform.parent = collision.transform; 
        }
         if (collision.gameObject.tag == "flag")
        {            
            Debug.Log("flag detected");
            moveButton.gameObject.SetActive(false);        
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {

        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
           Debug.Log("MovingPlatform detected");
           this.transform.parent = null;           
        }        
    }    

    void Update()   
    {         
        if (ifCharmCollected == 1)
        {
            dashButton.gameObject.SetActive(true);
            
        } else {
            dashButton.gameObject.SetActive(false);
        }
         int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

         if (currentSceneIndex ==0)
         {
             moveInput = 1;
         } else{
        
        moveInput = SimpleInput.GetAxis("Horizontal");
        keyboadInput = Input.GetAxis("Horizontal");
         }
         if (currentSceneIndex >= 100)
         {
             ifDoubleCharmCollected = 1;
         } else {
             ifDoubleCharmCollected = 0;
         }
          if (currentSceneIndex >= 13)
         {
             ifCharmCollected = 1;
         } else {
             ifCharmCollected = 0;
         }           
        rigidbody.velocity = new Vector2(moveInput * speed, rigidbody.velocity.y);

        if (moveInput > 0f || keyboadInput >0f)
        {
            gameObject.transform.localScale = new Vector2 ( 1, gameObject.transform.localScale.y );
            lastDirection = 2;           
             
        }else if (moveInput < 0f || keyboadInput < 0f){
            gameObject.transform.localScale = new Vector2 ( -1, gameObject.transform.localScale.y );
            lastDirection = 1;                      
        }

        if ((moveInput != 0 || keyboadInput !=0) && grounded == true)
        {  
            animator.SetBool("walking", true);
            

            if (grounded == true)
            {
                Instantiate(walkParticle,new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f),Quaternion.identity);
                
            }
        }else{
            animator.SetBool("walking", false);
            //runSound.Stop();
            //runSound.Play();
        }

        if (grounded == true)

        
        {   if (ifDoubleCharmCollected== 1)
        {
            jumpCount = 2;
        }
            else{
            jumpCount = 1;
        }
        }
         if (grounded == true){
            dashCount =1;
        }

        if(direction == 0)
        {
            if(ifDashPressed == true  || Input.GetKeyDown(KeyCode.LeftShift))
            {   
                if(lastDirection ==1 && ifCharmCollected == 1 && dashCount ==1)
                {  
                    Instantiate(dashParticle,new Vector2(gameObject.transform.position.x, gameObject.transform.position.y),Quaternion.identity);
                    animator.SetTrigger("dash");
                    camAnim.SetTrigger("zoomin");
                    direction = 1;
                    AudioSource.PlayClipAtPoint(dash,  transform.position);

                }else if (lastDirection ==2 && ifCharmCollected ==1 && dashCount ==1)
                {
                    Instantiate(dashParticle,new Vector2(gameObject.transform.position.x, gameObject.transform.position.y),Quaternion.identity);
                    animator.SetTrigger("dash");
                    camAnim.SetTrigger("zoomin");
                    direction = 2;
                    AudioSource.PlayClipAtPoint(dash,  transform.position);
                }
            }
        }else
        {
            if(dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rigidbody.velocity = Vector2.zero;
                //trailRenderer.widthCurve = new AnimationCurve(new Keyframe(0, 0.27f), new Keyframe(0.5f, 0.7f), new Keyframe(1, 0));
                Gradient gradient = new Gradient();
                gradient.SetKeys(
                    new GradientColorKey[] { new GradientColorKey(Color.cyan, 0.0f), new GradientColorKey(Color.white, 1.0f) },
                    new GradientAlphaKey[] { new GradientAlphaKey(1, 0.0f), new GradientAlphaKey(0, 1.0f) }
                );
                trailRenderer.colorGradient = gradient;
            }else
            {
                Gradient gradient2 = new Gradient();
                gradient2.SetKeys(
                    new GradientColorKey[] { new GradientColorKey(Color.red, 0.0f), new GradientColorKey(Color.yellow, 1.0f) },
                    new GradientAlphaKey[] { new GradientAlphaKey(1, 0.0f), new GradientAlphaKey(0, 1.0f) }
                );
                trailRenderer.colorGradient = gradient2;
                Instantiate(dashParticle,new Vector2(gameObject.transform.position.x, gameObject.transform.position.y),Quaternion.identity);
                dashTime -= Time.deltaTime;

                if(direction == 1 )
                {
                    rigidbody.velocity = Vector2.left * dashSpeed;
                     dashCount -= 1;
                     ifDashPressed = false;
                }else if (direction == 2)
                {
                    rigidbody.velocity = Vector2.right * dashSpeed;
                    dashCount -= 1;
                    ifDashPressed = false;

                }
            }
        }

        if (grounded)
        {
            hangCounter = hangTime;
            
        } else {

            hangCounter -= Time.deltaTime;
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && hangCounter > 0f)
        {
              isJumping = false;

        if( jumpCount > 0) // && grounded == true)
        {
            for(int i = 0;i <= 50;i++)
            {
                Instantiate(walkParticle,new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f),Quaternion.identity);
            }

        if (reversePlayer == true)
        {
            animator.SetTrigger("jump");
            AudioSource.PlayClipAtPoint(jump,  transform.position);
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, -jumpSpeed);
            grounded = false;
            jumpCount -= 1;
            jumpTimeCounter = jumpTime;
            isJumping = true;
        }

        if (reversePlayer == false)
        {

            animator.SetTrigger("jump");
            AudioSource.PlayClipAtPoint(jump,  transform.position);
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpSpeed);
            grounded = false;
            jumpCount -= 1;
            jumpTimeCounter = jumpTime;
            isJumping = true;
        }      

        if( grounded == false && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {               
                jumpTimeCounter -= Time.deltaTime;
            }else{
                isJumping = false;
                 
            }
        }  
        }
        }

        if (Input.GetKeyUp(KeyCode.UpArrow)) //&& rigidbody.velocity.y > 0)
        {   
            if (reversePlayer == false && rigidbody.velocity.y > 0)
            {
                rigidbody.velocity = new Vector2 (rigidbody.velocity.x, jumpSpeed * 0.2f);
            }

            if (reversePlayer == true && rigidbody.velocity.y < 0)
            {
                rigidbody.velocity = new Vector2 (rigidbody.velocity.x, jumpSpeed * -0.2f);
            }
            
        }
    }
    
    public void Jump(){

        if (hangCounter > 0)
        {            

         isJumping = false;

        if( jumpCount > 0) // && grounded == true)
        {
            for(int i = 0;i <= 50;i++)
            {
                Instantiate(walkParticle,new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f),Quaternion.identity);
            }

            animator.SetTrigger("jump");
            AudioSource.PlayClipAtPoint(jump,  transform.position);
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpSpeed);
            grounded = false;
            jumpCount -= 1;                        
            jumpTimeCounter = jumpTime;
            isJumping = true;
        }      

        if( grounded == false && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {               
                jumpTimeCounter -= Time.deltaTime;
            }else{
                isJumping = false;
            }
        }  
    }
}

    public void JumpButtonOff(){

        if (rigidbody.velocity.y >0)
        {
            rigidbody.velocity = new Vector2 (rigidbody.velocity.x, jumpSpeed * 0.2f);
        }

    }

    public void Dash(){

        if (ifCharmCollected ==1)
        {
             ifDashPressed = true;
        }        
    }
        IEnumerator LoadLevel (int levelIndex) {
        transition.SetTrigger("start");
        yield return new WaitForSeconds (transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

     IEnumerator Death (int levelIndex) {

        AudioSource.PlayClipAtPoint(death,  camPosition.position);
        animator.SetTrigger("death");
        yield return new WaitForSeconds (transitionTime - 0.4f);
        transition.SetTrigger("start");
        yield return new WaitForSeconds (transitionTime);
        SceneManager.LoadScene(levelIndex);

    }
}