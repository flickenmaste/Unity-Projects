using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float health = -1;
    private float maxHealth = 100;
    public LayerMask mask = -1;

	// Use this for initialization
	void Start () 
    {
        health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () 
    {
        CheckForEnemy();
        CheckInput();
        CheckHealth();
        this.rigidbody2D.velocity = new Vector2(0, 0);
	}

    void CheckInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //this.gameObject.transform.position += (new Vector3(0, 0, 250f) * Time.deltaTime);
            this.rigidbody2D.AddForce(new Vector2(0, 250f));
        }
        if (Input.GetKey(KeyCode.S))
        {
            //this.gameObject.transform.position += (new Vector3(0, 0, -250f) * Time.deltaTime);
            this.rigidbody2D.AddForce(new Vector2(0, -250f));
        }
        if (Input.GetKey(KeyCode.A))
        {
            //this.gameObject.transform.position += (new Vector3(-250f, 0, 0) * Time.deltaTime);
            this.rigidbody2D.AddForce(new Vector2(-250f, 0f));
        }
        if (Input.GetKey(KeyCode.D))
        {
            //this.gameObject.transform.position += (new Vector3(250f, 0, 0) * Time.deltaTime);
            this.rigidbody2D.AddForce(new Vector2(250f, 0f));
        }
    }

    void CheckForEnemy()
    {
        mask = LayerMask.GetMask("Enemy");
        RaycastHit2D hit;
        hit = Physics2D.CircleCast(this.rigidbody2D.position, 2.0f, Vector2.zero, 2.0f, mask.value);
        if (hit)
        {
            if (hit.collider.tag == "Enemy")
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    var attack = Random.Range(5, 25);
                    hit.collider.gameObject.GetComponent<Enemy>().Health += -attack;
                }
            }
        }
    }

    void CheckHealth()
    {
        if (health <= 0)
        {
            Application.LoadLevel("level_one");
        }
    }

    //void OnDrawGizmos()
    //{
    //    //Gizmos.DrawSphere(new Vector3(this.rigidbody2D.position.x, this.rigidbody2D.position.y, 0), 1.0f);
    //}
}
