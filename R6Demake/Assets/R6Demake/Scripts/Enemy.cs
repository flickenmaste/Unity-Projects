using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public GameObject player;
    public Ray targetEnemy;
    public Rigidbody bullet;
    public float nextFire = -1.0f;
    public float speed = 100.0f;
    public bool isFlashed = false;
    public float nextFlash = -1.0f;
    
    // Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        FollowEnemy();
	}

    void FollowEnemy()
    {
        RaycastHit hit;
        if (!isFlashed)
        {
            if (Physics.Linecast(this.rigidbody.position, player.rigidbody.position, out hit))
            {
                if (hit.collider.tag == "Player")
                {
                    if (Time.time >= nextFire)
                    {
                        var rotate = Quaternion.LookRotation(player.transform.position - this.transform.position);
                        this.transform.rotation = Quaternion.Slerp(transform.rotation, rotate, speed);
                        Shoot();
                        nextFire = Time.time + 1.0f;
                    }
                }
            }
        }
        if (isFlashed)
        {
            StartCoroutine(CheckFlashed());
        }
        Debug.DrawLine(this.rigidbody.position, player.rigidbody.position);
    }

    void Shoot()
    {
        Rigidbody Eclone;
        Eclone = Instantiate(bullet, this.rigidbody.position, Quaternion.identity) as Rigidbody;
        Physics.IgnoreCollision(this.collider, Eclone.collider);
        Eclone.velocity += this.transform.forward * 10;
    }

    IEnumerator CheckFlashed()
    {
        yield return new WaitForSeconds(3);
        isFlashed = false;
    }
}
