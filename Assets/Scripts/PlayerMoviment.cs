using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMoviment : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private bool grounded;
    private bool plataform;
    private SpriteRenderer sprite;

    private int flowerCounter = 0;
    public TMP_Text counterText;

    public TextMeshProUGUI WINTEXT;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed,body.velocity.y);

        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();

        if (Input.GetKey(KeyCode.Space) && plataform)
            Jump();

        if (body.velocity.x < 0f)
        {
            sprite.flipX = true;
        }
        if (body.velocity.x > 0f)
        {
            sprite.flipX = false;
        }
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        grounded = false;

        body.velocity = new Vector2(body.velocity.x, speed);
        plataform = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;

        if (collision.gameObject.tag == "FloatingPlataform")
            plataform = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Win")
        {
            WINTEXT.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        if (collision.CompareTag("Ground"))
        {
            grounded = true;
        }
        else if (collision.CompareTag("Flower") && collision.gameObject.activeSelf == true)
        {
            collision.gameObject.SetActive(false);
            flowerCounter += 1;
            counterText.text = "Flowes: " + flowerCounter;
        }
    }
}
