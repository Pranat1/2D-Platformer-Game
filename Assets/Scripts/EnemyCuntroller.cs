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
    int lives;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController scriptPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        lives = scriptPlayer.lives;
        GameObject[] gameLife = GameObject.FindGameObjectsWithTag("Life");
        if(collision.gameObject.GetComponent<PlayerController>() != null){
            lives -= 1;
            scriptPlayer.SetLives(lives);
            if(lives >= 0)
            {
                gameLife[lives].SetActive(false);
            }
            if (lives == 0){

            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.KillPlayer();
            }
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
