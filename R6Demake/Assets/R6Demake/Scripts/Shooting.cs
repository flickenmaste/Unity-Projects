using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

    public Vector3 rayDirection;
    public Vector3 shootDirection;
    public GameObject gun;
    public Rigidbody bullet;
    public Vector3 leanVec;
    public KeyCode lastMoveKey;
    public bool isLeaning = false;
    public float nextFire = -1.0f;
    public Camera mainCam;
    
    // Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
        ChangeAim();
        lean();
        if (isLeaning == true)
        {
            Debug.DrawRay(leanVec, rayDirection, Color.red);
            gun.gameObject.transform.position = (leanVec + rayDirection);
        }
        else if (isLeaning == false)
        {
            Debug.DrawRay(this.gameObject.transform.position, rayDirection, Color.red);
            gun.gameObject.transform.position = (this.gameObject.transform.position + rayDirection);
        }
        Shoot();
	}

    void ChangeAim()
    {
        if (!Input.GetKey(KeyCode.Space))
        {
            if (Input.GetKey(KeyCode.W))
            {
                rayDirection = new Vector3(0, 0, 1);
                gun.gameObject.transform.position = (this.gameObject.transform.position + rayDirection);
                shootDirection = new Vector3(0, 0, 1);
                lastMoveKey = KeyCode.W;
                isLeaning = false;
            }
            if (Input.GetKey(KeyCode.S))
            {
                rayDirection = new Vector3(0, 0, -1);
                gun.gameObject.transform.position = (this.gameObject.transform.position + rayDirection);
                shootDirection = new Vector3(0, 0, -1);
                lastMoveKey = KeyCode.S;
                isLeaning = false;
            }
            if (Input.GetKey(KeyCode.A))
            {
                rayDirection = new Vector3(-1, 0, 0);
                gun.gameObject.transform.position = (this.gameObject.transform.position + rayDirection);
                shootDirection = new Vector3(-1, 0, 0);
                lastMoveKey = KeyCode.A;
                isLeaning = false;
            }
            if (Input.GetKey(KeyCode.D))
            {
                rayDirection = new Vector3(1, 0, 0);
                gun.gameObject.transform.position = (this.gameObject.transform.position + rayDirection);
                shootDirection = new Vector3(1, 0, 0);
                lastMoveKey = KeyCode.D;
                isLeaning = false;
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            gun.gameObject.transform.position = (this.gameObject.transform.position + rayDirection);
        }
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time >= nextFire)
            {
                Rigidbody clone;
                clone = Instantiate(bullet, gun.gameObject.transform.position, Quaternion.identity) as Rigidbody;
                clone.velocity += shootDirection * 10;
                nextFire = Time.time + 0.4f;
            }
        }
    }
    
    void lean()
    {
        if (lastMoveKey == KeyCode.W)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                isLeaning = true;
                leanVec = new Vector3(this.transform.position.x - 0.5f, this.transform.position.y, this.transform.position.z);
            }
            if (Input.GetKey(KeyCode.E))
            {
                isLeaning = true;
                leanVec = new Vector3(this.transform.position.x + 0.5f, this.transform.position.y, this.transform.position.z);
            }
        }
        if (lastMoveKey == KeyCode.S)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                isLeaning = true;
                leanVec = new Vector3(this.transform.position.x - 0.5f, this.transform.position.y, this.transform.position.z);
            }
            if (Input.GetKey(KeyCode.E))
            {
                isLeaning = true;
                leanVec = new Vector3(this.transform.position.x + 0.5f, this.transform.position.y, this.transform.position.z);
            }
        }
        if (lastMoveKey == KeyCode.A)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                isLeaning = true;
                leanVec = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 0.5f);
            }
            if (Input.GetKey(KeyCode.E))
            {
                isLeaning = true;
                leanVec = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 0.5f);
            }
        }
        if (lastMoveKey == KeyCode.D)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                isLeaning = true;
                leanVec = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 0.5f);
            }
            if (Input.GetKey(KeyCode.E))
            {
                isLeaning = true;
                leanVec = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 0.5f);
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            isLeaning = false;
            gun.gameObject.transform.position = (this.gameObject.transform.position + rayDirection);
        }
    }
}
