using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Animator anim;
    Rigidbody rgb;
    public float speed = 5;
    public float rotateSpeed = 90;
    public Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rgb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (v < 0)
        {
            v = 0;
        }

        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {
            transform.Rotate(Vector3.up, Mathf.Clamp(180f * Time.deltaTime, 0f, 360f));
        }
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
        {
            transform.Rotate(Vector3.up, -Mathf.Clamp(180f * Time.deltaTime, 0f, 360f));
        }

        if (v != 0)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }
       
        moveDirection = new Vector3(0, 0, v);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        rgb.velocity = moveDirection;   
    }
}

