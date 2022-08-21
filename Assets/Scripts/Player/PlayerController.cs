using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ScoreCuntroller scoreCuntroller;
    [SerializeField] private Animator animator;
    [SerializeField] private float speed = 2f;
    [SerializeField] private Rigidbody2D rB2d;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private GameObject UnityButton;
    [SerializeField] private GameObject CanvosObj;
    [SerializeField] private int lives = 3; 
    [SerializeField] private GameOverCuntroller gameOver;
    [SerializeField] private EnemyCuntroller[] CuntrollerObj;


    // Start is called before the first frame update
    private void Awake(){
        rB2d = gameObject.GetComponent<Rigidbody2D>();
    }

    internal void KillPlayer()
    {
        Debug.Log("Player Killed By Enemy");
        animator.SetBool("Die", true);
        SoundManager.Instance.PlayMusic(Sounds.PlayerDeath);
    }

    public void ButtonAppear()
        {
        gameOver.GameOverMethod();
        gameObject.GetComponent<PlayerController>().enabled = false;
        for (int i = 0; i < CuntrollerObj.Length; i++){
            CuntrollerObj[i].enabled = false;
        }

    }

    public void PickUpKey()
    {
        Debug.Log("Player picked up the key");
        scoreCuntroller.IncreaseScore(10);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float verticle = Input.GetAxisRaw("Jump");
        

        MoveCharector(horizontal, verticle);
        methodAnimationRun(horizontal, verticle);

        animator.SetBool("Crowch", Input.GetButton("Fire1"));
        

    
    }


    private void methodAnimationRun(float horizontal, float verticle){
        
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;
        if (horizontal < 0 && scale.x > 0)
        {
            scale.x = -1f* scale.x;
        }
        else if(horizontal > 0){
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
        

        animator.SetBool("Jump", verticle > 0);

    }
    private void MoveCharector(float horizontal, float verticle){
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        if (verticle > 0 && isGrounded){
        isGrounded = false;
        rB2d.AddForce(new Vector2(0f,jumpForce), ForceMode2D.Impulse);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
    public void SetLives(int newLives)
    {
        lives = newLives;
    }
    public int GetLives()
    {
        return lives;
    }

}
