using UnityEngine;

public class Player_2 : MonoBehaviour
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

            //+ codigo da anima��o   
        }


    }

    void Jump()
    {
        if (!PlayerNumber)
        {
            if (Input.GetButtonDown("Jump") && !isJumping)//O bot�o jump � definido no ambiente da unity. por padr�o � space.
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                anim.SetBool("jump", true);

            }
        }

        if (PlayerNumber)
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
}
