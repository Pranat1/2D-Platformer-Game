using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCuntroller : MonoBehaviour
{
    public GameObject PlayerDeath1;
    public float speed;
    public float distance = 5f;
    public bool moveRight = true;
    public Transform groundDetection;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null){
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.KillPlayer();
        }
    }
    void Update()
    {
        transform.Translate(Vector2.right*speed*Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        Debug.Log(groundInfo.collider);
        if(groundInfo.collider == PlayerDeath1.GetComponent<BoxCollider2D>()){
            if(moveRight == true){
                transform.eulerAngles = new Vector3(0,-180,0);
                moveRight =false;
            }
            else{
                    transform.eulerAngles = new Vector3(0,0,0);
                    moveRight =true;

            }
        }
    }
}
