using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMove1 : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;

    //スピード
    public float moveSpeed = 500f;
    //ジャンプ力 
    public float jumpPower = 2000f;
    //ジャンプ回数
    int jumpCount = 0;    
    public LayerMask groundLayer;
    int key = 0;
    bool isGrounded =true;    

    GameObject Camera;
    Pause pausescript;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //GravityScale
        rb2d.gravityScale = 800;

        animator = GetComponent<Animator>();
        Camera = GameObject.FindWithTag("Menu");
        pausescript = Camera.GetComponent<Pause>();
    }

    void Update()
    {     
        if (pausescript.pause)
        {
            GetInput();
            Move();

            //Playerの中央から足元にかけて、接地判定のラインを引く
            /*isGrounded = Physics2D.Linecast(
                transform.position,
                transform.position - transform.up * 36,
                groundLayer); //Linecastが判定するレイヤー    
                              //LinecastにPlayerが接地していれば、isGroundはtrueを返す  */


            print(transform.right*10);

            //print(isGrounded);
        
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Block") {
            isGrounded = true;
        }
        
    }

    void GetInput()
    {
        if (Input.GetButtonDown("Jump")) {
            Jump();
        }
        else if (isGrounded) //isGroundがtrueなら
        {
            jumpCount = 0; //ジャンプカウントを初期化
        }


        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            key = 1;
            animator.SetBool("walk", true);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            key = -1;
            animator.SetBool("walk", true);
        } else
        {
            key = 0;
            animator.SetBool("walk", false);
        }  
    }

    void Move()
    {
        if (key != 0)
        {
            this.transform.position += new Vector3(moveSpeed * Time.deltaTime * key, 0, 0);
            transform.localScale = new Vector2(key, transform.localScale.y);
        }
    }

    public void Jump()
    {
        //ジャンプカウントが1未満のとき
        /* if (jumpCount < 1)
         {
             jumpCount++; //ジャンプカウントをプラスする

             //ジャンプ
             GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpPower);
             animator.SetTrigger("jump");

             isGrounded = false; //isGroundをfalseにする            
         }*/

        if (isGrounded) {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpPower);
            animator.SetTrigger("jump");

            isGrounded = false; //isGroundをfalseにする   

        }
    }
}
