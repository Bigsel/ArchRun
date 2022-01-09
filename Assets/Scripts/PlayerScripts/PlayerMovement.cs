using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;

    private Rigidbody2D rb2D;

    private float moveSpeed;
    private float jumpForce;
    private bool isJumping;
    private float moveHorizontal;
    private float moveVertical;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        // Získávání Rigidbody2D
        rb2D = gameObject.GetComponent<Rigidbody2D>();

        // Nastavení hodnot
        jumpForce = 35f;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void FixedUpdate()
    {
        // Nastavení skoku po dotknutí obrazovky
        if (!isJumping && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            rb2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, Camera.main.transform.position.z));
            
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = false;
            anim.SetBool("isJump", false);
        } 
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = true;
            anim.SetBool("isJump", true);
        }
    }

}

