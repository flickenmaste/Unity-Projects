using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    
    // Use this for initialization
	void Start () 
    {
        this.gameObject.renderer.material.color = Color.green;
	}
	
	// Update is called once per frame
	void Update () 
    {
        this.rigidbody.velocity = new Vector3(0, 0, 0);
	}

    void FixedUpdate()
    {
        CheckInput();
    }

    void CheckInput()
    {
        // Get players running speed
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.W))
            {
                //this.gameObject.transform.position += (new Vector3(0, 0, 250f) * Time.deltaTime);
                this.rigidbody.AddForce(0, 0, 250f, ForceMode.Acceleration);
            }
            if (Input.GetKey(KeyCode.S))
            {
                //this.gameObject.transform.position += (new Vector3(0, 0, -250f) * Time.deltaTime);
                this.rigidbody.AddForce(0, 0, -250f, ForceMode.Acceleration);
            }
            if (Input.GetKey(KeyCode.A))
            {
                //this.gameObject.transform.position += (new Vector3(-250f, 0, 0) * Time.deltaTime);
                this.rigidbody.AddForce(-250f, 0, 0, ForceMode.Acceleration);
            }
            if (Input.GetKey(KeyCode.D))
            {
                //this.gameObject.transform.position += (new Vector3(250f, 0, 0) * Time.deltaTime);
                this.rigidbody.AddForce(250f, 0, 0, ForceMode.Acceleration);
            }
        }

        // Get players walking speed
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.W))
            {
                //this.gameObject.transform.position += (new Vector3(0, 0, 100f) * Time.deltaTime);
                this.rigidbody.AddForce(0, 0, 100f, ForceMode.Acceleration);
            }
            if (Input.GetKey(KeyCode.S))
            {
                //this.gameObject.transform.position += (new Vector3(0, 0, -100f) * Time.deltaTime);
                this.rigidbody.AddForce(0, 0, -100f, ForceMode.Acceleration);
            }
            if (Input.GetKey(KeyCode.A))
            {
                //this.gameObject.transform.position += (new Vector3(-100f, 0, 0) * Time.deltaTime);
                this.rigidbody.AddForce(-100f, 0, 0, ForceMode.Acceleration);
            }
            if (Input.GetKey(KeyCode.D))
            {
                //this.gameObject.transform.position += (new Vector3(100f, 0, 0) * Time.deltaTime);
                this.rigidbody.AddForce(100f, 0, 0, ForceMode.Acceleration);
            }
        }
    }
}
