using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionStay(Collision c)
    {
        if (c.gameObject.tag == "Player")
        {
            Application.LoadLevel("level_one");
        }

        if (c.gameObject.tag == "Enemy")
        {
            DestroyObject(c.gameObject, 0);
        }
        
        DestroyObject(this.gameObject, 0f);
    }
}
