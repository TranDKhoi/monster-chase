using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //CONSTANTS
    private const string HORIZONTAL_AXIS = "Horizontal";
    private const string VERTICAL_AXIS = "Vertical";
    private const string WALK_ANIMATION = "Walk";
    private const string JUMP_ANIMATION = "Jump";
    private const string GROUND_TAG = "Ground";
    private const string ENEMY_TAG = "Enemy";


    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    private SpriteRenderer sr;

    private Rigidbody2D myBody;

    private Animator anim;


    private bool isOnGround;

    void Awake()
    {
        _mapping();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isOnGround = true;
        }
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
            GameplayUIController.ins.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
            GameplayUIController.ins.gameObject.SetActive(true);
        }
    }

    private void PlayerJump()
    {
        if (Input.GetButtonDown(JUMP_ANIMATION) && isOnGround)
        {
            isOnGround = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void AnimatePlayer()
    {
        if (movementX != 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = movementX > 0 ? false : true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    private void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw(HORIZONTAL_AXIS);

        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    private void _mapping()
    {
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

} //class
