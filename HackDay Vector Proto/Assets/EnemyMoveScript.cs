using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour
{

    [SerializeField] public bool isGrounded = false;
    [SerializeField] public Vector2 vel;
    [SerializeField] public Vector2 direction = new Vector2(0f, 0f);
    [SerializeField] public float smallBoostPower;
    [SerializeField] public float bigBoostPower;

    //private static float degrees = 45f;
    private Rigidbody2D rb2d;
    private float raycastDistance = 0.5f;
    private int groundLayerMask;
    private float enemyDir = 1.0f;
    private int forcecounter = 0;

    // Use this for initialization
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        groundLayerMask = LayerMask.GetMask("Ground & Platforms");
        vel = rb2d.velocity;

    }

    void Update()
    {
        //UpdateInput();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //CheckIsGrounded();
        Move();
        //UpdateSpeed();
        vel = rb2d.velocity;
    }

    public void CheckIsGrounded()
    {
        BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>();
        RaycastHit2D hits = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y) - new Vector2(0f, collider.size.y * transform.localScale.y), new Vector2(0f, -1f), raycastDistance, groundLayerMask, -Mathf.Infinity, Mathf.Infinity);
        if (hits.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    /*public void UpdateInput()
    {
        if (Input.GetKeyDown("d"))
        {
            direction += new Vector2(1f, 0f);
        }
        if (Input.GetKeyDown("w"))
        {
            direction += new Vector2(0f, 1f);
        }
        if (Input.GetKeyDown("a"))
        {
            direction += new Vector2(-1f, 0f);
        }
        if (Input.GetKeyDown("s"))
        {
            direction += new Vector2(0f, -1f);
        }

        if (Input.GetKeyUp("d"))
        {
            direction += new Vector2(-1f, 0f);
        }
        if (Input.GetKeyUp("w"))
        {
            direction += new Vector2(0f, -1f);
        }
        if (Input.GetKeyUp("a"))
        {
            direction += new Vector2(1f, 0f);
        }
        if (Input.GetKeyUp("s"))
        {
            direction += new Vector2(0f, 1f);
        }

    }*/

    public void Move()
    {
        /*if (Input.GetKeyDown("j"))
        {
            rb2d.AddForce(smallBoostPower * direction.normalized, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown("k"))
        {
            rb2d.AddForce(bigBoostPower * direction.normalized, ForceMode2D.Impulse);
        }*/
        if(transform.position.x > -6.0f)
        {
            //direction.Set(-1.0f, 0.0f);
            enemyDir = -1.0f;
            //Debug.Log("X vel set to -1");
        }
        else if(transform.position.x < -9.0f)
        {
            //direction.Set(1.0f, 0.0f);
            enemyDir = 1.0f;
            //Debug.Log("X vel set to 1");
        }
        //rb2d.velocity.Set(enemyDir,0.0f);
        direction = new Vector2(enemyDir, 0.0f);
        if (true)// forcecounter < 50)
        {
            ///Debug.Log("applying force: " + direction.normalized);
            rb2d.AddForce(direction.normalized * 0.25f, ForceMode2D.Impulse);
            forcecounter++;
        }
        //rb2d.AddForce(bigBoostPower * direction, ForceMode2D.Impulse);

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("ONCollider called.");
    }

}
