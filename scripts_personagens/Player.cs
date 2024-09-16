using UnityEngine;

public class Player : MonoBehaviour

    
{

    public float Speed;
    public float JumpForce;

    public bool PlayerNumber;

    public bool isJumping;
    public bool doubleJump;

    private Rigidbody2D rig;
    private Animator anim;

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
    }

    void Move() 
    {
        if (!PlayerNumber)
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += movement * Time.deltaTime * Speed;


            if (Input.GetAxis("Horizontal") > 0f && !isJumping)//quando tiver andando pra a direita (esse && !isJumping é gambiarra)
            {
                anim.SetBool("walk", true);
            }

            if (Input.GetAxis("Horizontal") < 0f && !isJumping)//quando tiver andando pra a esquerda (esse && !isJumping é gambiarra)
            {
                anim.SetBool("walk", true);
            }

            if (Input.GetAxis("Horizontal") == 0f)//quando tiver parado
            {
                anim.SetBool("walk", false);
            }
        }
        if (PlayerNumber)
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

            //+ codigo da animação
        }


    }

    void Jump()
    {
        if (!PlayerNumber)
        {
            if (Input.GetButtonDown("Jump") && !isJumping)//O botão jump é definido no ambiente da unity. por padrão é space.
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                anim.SetBool("jump", true);

            }
            
        }

        if (PlayerNumber)
        {
            if (Input.GetKeyDown(KeyCode.W) && !isJumping)//O botão jump é definido no ambiente da unity. por padrão é space.
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                //anim.SetBool("jump", true);

            }

        }
       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = false;
            anim.SetBool("jump", false);
            
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = true;
            anim.SetBool("walk", false);
        }
    }
}
