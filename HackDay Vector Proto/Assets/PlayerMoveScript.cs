using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour {

    private Rigidbody2D rb2d;
    [SerializeField] public bool isGrounded = false;

    private static float degrees = 45f;
    private float direction = 0f;
    private float raycastDistance = 0.5f;
    private int groundLayerMask;
    [SerializeField] public float smallBoostPower;
    [SerializeField] public float bigBoostPower;

	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D>();
        groundLayerMask = LayerMask.GetMask("Ground & Platforms");

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        CheckIsGrounded();
		UpdateInput();

	}

    public void CheckIsGrounded(){
        BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>();
        RaycastHit2D hits = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y) - new Vector2(0f, collider.size.y * transform.localScale.y), new Vector2(0f, -1f), raycastDistance, groundLayerMask, -Mathf.Infinity, Mathf.Infinity );
        if(hits.collider != null){
            isGrounded = true;
        }
        else{
            isGrounded = false;
        }
    }

    public void UpdateInput(){
        if(Input.GetKeyDown("w")){
            Debug.Log("W key pressed");
        }
    }

    public void OnColliderEnter2D(Collision collision){

    }
}
