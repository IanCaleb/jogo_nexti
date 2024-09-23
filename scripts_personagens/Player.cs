using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    public float PlayerNumber;

    public bool isJumping;
    public bool doubleJump;

    private Rigidbody2D rig;
    private Animator anim;

    public GameObject outro_player;

    [SerializeField] private bool attackingBool;

   


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Giro();
        Animacoes();
        ATK();
    }

    void Move()
    {
        if (PlayerNumber == 1)
        {
            float customHorizontal = 0f;

            // Verifica as teclas personalizadas
            if (Input.GetKey(KeyCode.LeftArrow)) //enquanto apertar A
            {
                customHorizontal = -1f;
            }
            else if (Input.GetKey(KeyCode.RightArrow)) //enquanto apertar D
            {
                customHorizontal = 1f;
            }

            Vector3 movement = new Vector3(customHorizontal, 0f, 0f);
            transform.position += movement * Speed * Time.deltaTime;
            
        }
        if (PlayerNumber == 2) 
        {
            float customHorizontal = 0f;

            // Verifica as teclas personalizadas
            if (Input.GetKey(KeyCode.A)) //enquanto apertar A
            {
                customHorizontal = -1f;
            }
            else if (Input.GetKey(KeyCode.D)) //enquanto apertar D
            {
                customHorizontal = 1f;
            }

            Vector3 movement = new Vector3(customHorizontal, 0f, 0f);
            transform.position += movement * Speed * Time.deltaTime;

            //+ codigo da anima��o   
        }


    }

    void Jump()
    {
        if (PlayerNumber == 1)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && !isJumping)//O bot�o jump � definido no ambiente da unity. por padr�o � space.
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);

            }
        }

        if (PlayerNumber == 2)
        {
            if (Input.GetKeyDown(KeyCode.W) && !isJumping)//O bot�o jump � definido no ambiente da unity. por padr�o � space.
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                //anim.SetBool("jump", true);

            }
        }

        

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = false;
            //anim.SetBool("jump", false);

        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = true;
            //anim.SetBool("walk", false);
        }
    }

    void Giro()
    {
        if (outro_player.transform.position.x +1> transform.position.x)
        {
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }

        if(outro_player.transform.position.x +1< transform.position.x)
        {
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }


    }

    void Animacoes()
    {
        if(PlayerNumber == 1)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                anim.SetBool("walk", true);
                anim.SetBool("jump", false); 
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                anim.SetBool("walk", false);
            }
            /*
            ░▄▄▄▄░
            ▀▀▄██►
            ▀▀███►
            ░▀███►░█►
            ▒▄████▀▀
            
            */
        

        }

        if(PlayerNumber == 2)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                anim.SetBool("walk", true);
                anim.SetBool("jump", false); 
            }
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                anim.SetBool("walk", false);

            }
            /*
            ░▄▄▄▄░
            ▀▀▄██►
            ▀▀███►
            ░▀███►░█►
            ▒▄████▀▀
            
            */
        }

        if(isJumping)
        {
            anim.SetBool("jump", true);  
            anim.SetBool("walk", false);
        }

        if(!isJumping)
        {
           anim.SetBool("jump", false); 
        }


    }

    void ATK()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            attackingBool = true;
            anim.SetBool("ataque", true); 
            
            
        }


    }

    void Endanimation()
    {
        anim.SetBool("ataque", false);
        attackingBool = false;
    }
    
}