using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCuntroller : MonoBehaviour
{
    [SerializeField] private GameObject PlayerDeath1;
    [SerializeField] private float speed;
    [SerializeField] private float distance = 5f;
    [SerializeField] private bool moveRight = true;
    [SerializeField] private Transform groundDetection;
    int lives;
    [SerializeField] private PlayerController scriptPlayer;
    [SerializeField] private GameObject[] gameLife;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        lives = scriptPlayer.GetLives();
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
