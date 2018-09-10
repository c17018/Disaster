using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

[RequireComponent(typeof(Rigidbody2D),typeof(CapsuleCollider2D))]
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;

    //スピード
    public float moveSpeed = 500f;
    //ジャンプ力 
    public float jumpPower = 2000f;
    //ジャンプ回数
    int jumpCount = 0;
    bool jumpFlag = false;
    public LayerMask groundLayer;
    int key = 0;   
    bool isGrounded;
    //bool isPress = false;

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

        if (pausescript.pause) {
            //GetInput();
            Move();              

            //// 左右のキー変数
            //float h = Input.GetAxis("Horizontal");
            //// 速度の変数
            //Vector2 v = GetComponent<Rigidbody2D>().velocity;

            //if (h != 0) {
            //    // 左右の移動
            //    GetComponent<Rigidbody2D>().velocity = new Vector2(h * movespeed, v.y);
            //    transform.localScale = new Vector2(Mathf.Sign(h), transform.localScale.y);
            //    animator.SetBool("walk", true);
            //}
            //else
            //{              
            //    animator.SetBool("walk", false);
            //} 

            //Playerの中央から足元にかけて、接地判定のラインを引く
            isGrounded = Physics2D.Linecast(
                transform.position,
                transform.position - transform.up * 36,
                groundLayer); //Linecastが判定するレイヤー    
                              //LinecastにPlayerが接地していれば、isGroundはtrueを返す  
                              

            //if (Input.GetButtonDown("Jump"))
            //{
            //    Jump();                 
            //}

            if (isGrounded) //isGroundがtrueなら
            {
                jumpCount = 0; //ジャンプカウントを初期化
                jumpFlag = true;
            }           
        }            
    }

    //void GetInput()
    //{
    //    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
    //    {
    //        key = 1;
    //        animator.SetBool("walk", true);
    //    }
    //    else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
    //    {
    //        key = -1;
    //        animator.SetBool("walk", true);
    //    } /*else
    //    {
    //        key = 0;
    //        animator.SetBool("walk", false);
    //    }  */              
    //}  
    
    void Move()
    {
        if (key != 0)
        {
            this.transform.position += new Vector3(moveSpeed * Time.deltaTime * key, 0, 0);
            transform.localScale = new Vector2(key, transform.localScale.y);
        }
    }

    public void Rmove1()
    {
        if (pausescript.pause)
        {
            key = 1;
            //isPress = true;
            animator.SetBool("walk", true);
        }
    }
    public void Rmove2()
    {
        if (pausescript.pause)
        {
            key = 0;
            //isPress = false;
            animator.SetBool("walk", false);
        }
    }

    public void Lmove1()
    {
        if (pausescript.pause)
        {
            key = -1;
            //isPress = true;
            animator.SetBool("walk", true);
        }
    }
    public void Lmove2()
    {
        if (pausescript.pause)
        {
            key = 0;
            //isPress = false;
            animator.SetBool("walk", false);
        }
    }

    public void Jump()
    {
        if (jumpFlag == true)
        {
            jumpFlag = false;

            //ジャンプカウントが1未満のとき
            if (jumpCount < 1)
            {
                jumpCount = 1; //ジャンプカウントをプラスする
                //print("Jumpカウント++した");
                //print(jumpCount);  

                isGrounded = false; //isGroundをfalseにする  
                                    //print("isGroundedをfalseにした");
                                    //print(jumpCount);                  

                //ジャンプ
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpPower);
                animator.SetTrigger("jump");
                //print("ジャンプした");
                //print(jumpCount);   
                
            }
        }
    }
}

