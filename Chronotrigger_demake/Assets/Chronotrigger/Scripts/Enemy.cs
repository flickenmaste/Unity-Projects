using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private float health;
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            if (value != health)
            {
                health = value;
                OnHealthChanged();
            }
        }
    }
    public float showHp;
    private float maxHealth = 100;
    public GameObject Player;
    
    // Use this for initialization
	void Start () 
    {
        Health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () 
    {
        CheckHealth();
        showHp = health;
	}

    void CheckHealth()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject, 0);
        }
    }

    void OnHealthChanged()
    {
        var attack = Random.Range(2, 18);
        Player.gameObject.GetComponent<Player>().health += -attack;
    }
}
