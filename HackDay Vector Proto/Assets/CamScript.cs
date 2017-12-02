using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour {

    [SerializeField] public GameObject playerChar;
    [SerializeField] public float lerpRatio;
    [SerializeField] public float lookAhead;
    private Transform playerTransform;
    private float playerSpeed;
    private float camZPos;


	// Use this for initialization
	void Start () {
		playerTransform = playerChar.transform;
        camZPos = -10;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        //Lerp position between currentPos and player char's position.
        //Later change camera to update pos based on players position AND velocity

		//transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, camZPos);

        Vector2 charApproxPos = new Vector2(playerTransform.position.x, playerTransform.position.y);
        charApproxPos += playerChar.GetComponent<Rigidbody2D>().velocity * Time.deltaTime * lookAhead;
        Vector3 endPos = new Vector3(charApproxPos.x, charApproxPos.y, camZPos);

        transform.position = Vector3.Lerp(transform.position, endPos, lerpRatio);
	}
}
