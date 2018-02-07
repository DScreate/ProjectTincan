using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
public class SimplePlayerController : MonoBehaviour {

    public float speed;
    public float jumpForce;

    private Rigidbody2D _rigidbody2D;

    private bool isGrounded = false;
    private int planeIndex = 0;

	// Use this for initialization
	void Start () {
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.X))
        {
            planeIndex = (planeIndex + 1) % 2;
            PlaneController.SetActivePlane((Planes)planeIndex);
        }
    }

    void FixedUpdate()
    {
        float axis = Input.GetAxis("Horizontal");
        float axisVert = Input.GetAxis("Vertical");

        //Debug.Log(isGrounded);

        if (axis != 0f)
        {
            if (axis < 0)
                Move("left");
            else
                Move("right");
        }

        if (axisVert > 0 && isGrounded)
            Move("jump");
    }

    public void Move(string dir)
    {
        switch(dir)
        {
            case "left":
                _rigidbody2D.AddForce(new Vector2(-speed, 0));
                break;

            case "right":
                _rigidbody2D.AddForce(new Vector2(speed, 0));
                break;

            case "jump":
                _rigidbody2D.AddForce(new Vector2(0, jumpForce));
                isGrounded = false;
                break;

            default:
                break;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision2D)
    {
        isGrounded = true;
    }
}
