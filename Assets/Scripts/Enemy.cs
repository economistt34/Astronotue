using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
   public int health = 100;
   public float speed;

   public float distance;

//    public GameObject enemyParticle;

   private bool movingRight = true;

   public Transform groundDetection;


   void Update() {

       transform.Translate(Vector2.right * speed * Time.deltaTime);

    RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);

    if (groundInfo.collider == false)
    {
        if (movingRight == true)
        {
            transform.eulerAngles = new Vector3 (0, -180 , 0);
            movingRight = false;
        } else
        {
            transform.eulerAngles = new Vector3 (0, 0 , 0);
            movingRight = true;
        }
    }

       
   }

//     public void TakeDemage( int demage) {

//         health -= demage;
    
//         if (health <= 0)
//         {
//             Die();
//         }

//         void Die(){

//             Destroy(gameObject);
//             Instantiate(enemyParticle, transform.position, Quaternion.identity);
//         }
// }
}
