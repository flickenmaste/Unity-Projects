using UnityEngine;
using System.Collections;

public class FlashDestroy : MonoBehaviour {

    public Vector3 myPos;
    public Ray myRay;
    public GameObject flashSprite;

    // Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        myPos = this.gameObject.transform.position;
	}

    void OnDestroy()
    {
        GameObject clone;
        clone = Instantiate(flashSprite, myPos, Quaternion.identity) as GameObject;
        Destroy(clone.gameObject, 0.5f);
        Collider[] hit = Physics.OverlapSphere(myPos, 5.0f);
        for (var i = 0; i < hit.Length; i++)
        {
            if (hit[i].gameObject.tag == "Enemy")
            {
                hit[i].GetComponent<Enemy>().isFlashed = true;
            }
        }
    }
}
