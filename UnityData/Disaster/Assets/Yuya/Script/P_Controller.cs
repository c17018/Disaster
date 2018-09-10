using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class P_Controller : MonoBehaviour
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
    bool isGrounded;
    string sceneName;
    GameObject Camera;
    Pause pausescript;

    private void Awake()
    {
        Input.multiTouchEnabled = false;
        sceneName = SceneManager.GetActiveScene().name;
    }

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
            Move();             

            //Playerの中央から足元にかけて、接地判定のラインを引く
            isGrounded = Physics2D.Linecast(
                transform.position,
                transform.position - transform.up * 36,
                groundLayer); //Linecastが判定するレイヤー    
                              //LinecastにPlayerが接地していれば、isGroundはtrueを返す 

            if (isGrounded) //isGroundがtrueなら
            {
                jumpCount = 0; //ジャンプカウントを初期化
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) Rmove1();
            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)) Rmove2();
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) Lmove1();
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) Lmove2();
            if (Input.GetButtonDown("Jump")) Jump();              
            
        }

        if (this.transform.position.y < -600.0f)
        {
            if (SceneManager.GetActiveScene().name == sceneName)
            {
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                SceneManager.LoadScene(0);
            }

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
        //ジャンプカウントが1未満のとき
        if (jumpCount < 1)
        {
            jumpCount++; //ジャンプカウントをプラスする

            //ジャンプ
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpPower);
            animator.SetTrigger("jump");

            isGrounded = false; //isGroundをfalseにする          
        }
    }

    public void Jump2()
    {   
        //ジャンプカウントが1未満のとき
        if (jumpCount < 1)
        {
            isGrounded = false; //isGroundをfalseにする
                                //jumpCount++; //ジャンプカウントをプラスする                        

            //ジャンプ
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpPower);
            animator.SetTrigger("jump");

        }    
    } 
    public void Jump3()
    {
        jumpCount++; //ジャンプカウントをプラスする 
    }
}
