using UnityEngine;
using System.Collections;

public class Flashbang : MonoBehaviour {

    public GameObject flashbang;
    public GameObject gun;
    public int flashAmmo = 2;
    public float flashDuration = 0.5f;
    public float nextFire = -1.0f;
    
    // Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
        ThrowFlashbang();
	}

    void ThrowFlashbang()
    {
        if (flashAmmo > 0)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (Time.time >= nextFire)
                {
                    GameObject clone;
                    clone = Instantiate(flashbang, gun.gameObject.transform.position, Quaternion.identity) as GameObject;
                    clone.rigidbody.velocity = GetComponent<Shooting>().shootDirection * 8;
                    nextFire = Time.time + 0.9f;
                    ActivateFlash(clone);
                    flashAmmo--;
                }
            }
        }
    }

    void ActivateFlash(GameObject clone)
    {
        Destroy(clone, flashDuration);
    }
}
