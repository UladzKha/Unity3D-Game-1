using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;
    private float movementX;
    [SerializeField]
    private Rigidbody2D myBody;
    private Animator anim;
    private SpriteRenderer sr;
    private bool isGrounded;

    private const string WALK_ANIMATION = "Walk";
    private const string ENEMY_TAG = "Enemy";
    private const string GROUND_TAG = "Ground";
    private const string HEART_0 = "heart0";
    private const string HEART_1 = "heart1";
    private const string HEART_2 = "heart2";
    private int lifes = 3;

    private string[] hearts = new string[] { "heart0", "heart1", "heart2" };

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

    }

    void Start()
    {

    }

    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void AnimatePlayer()
    {
        if (movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        if (movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
       if(movementX == 0) anim.SetBool(WALK_ANIMATION, false);
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
            isGrounded = true;

        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            var heartObj = GameObject.FindGameObjectWithTag(hearts[lifes - 1]);
            lifes -= 1;
            Destroy(heartObj);

            if(lifes < 1) Destroy(gameObject);
        }
    }
}
