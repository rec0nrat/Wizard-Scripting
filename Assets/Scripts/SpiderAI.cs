using UnityEngine;
using System.Collections;

public class SpiderAI : MonoBehaviour 
{   
    NavMeshAgent navAgent;
    Transform t;

    public int maxHealth = 100; 
    int health;
    public int damage = 5;

    public int rateOfAttack = 60; 
    int attackTimer = 0;

    enum spider_state
    {
        IDOL,
        CHASE,
        ATTACK
    }

    spider_state _spiderState;
    Transform playerP;
    int playerMask = (1 << 8);

	// Use this for initialization
	void Start () 
    {
	    navAgent = GetComponent<NavMeshAgent>();
        t = GetComponent<Transform>();
        _spiderState = spider_state.IDOL;
        playerP = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        health = maxHealth; 
	}
	
	// Update is called once per frame
	void Update () 
    {
        RunState();
	}

    private void RunState()
    {
        switch (_spiderState)
        {
            case spider_state.IDOL:
            {
                
            }break;

            case spider_state.CHASE:
            {
                NavMeshPath path = new NavMeshPath();
                if (navAgent.CalculatePath(playerP.position, path))
                {
                    if (navAgent.SetPath(path))
                    {
                        
                    }
                }
                
                //RaycastHit hit;
                if (Physics.Raycast(t.position, transform.forward, 3, playerMask))
                {
                    SetState(spider_state.ATTACK);
                    navAgent.Stop(); 
                    //print("SphereCast went off");
                }
            }break;

            case spider_state.ATTACK:
            {
                Attack();
                if (!Physics.Raycast(t.position, transform.forward, 3, playerMask))
                {
                    SetState(spider_state.CHASE);
                }

            }break; 
        }
    }

    void Attack()
    {
        ++attackTimer;

        if (attackTimer >= rateOfAttack)
        {
            attackTimer = 0;

            GameManager.instance.player.ApplyDamage(damage);
        }
    }

    void SetState(spider_state state)
    {
        _spiderState = state; 
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            SetState(spider_state.CHASE);
        }
    }

    public void ApplyDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            // TODO(barret): what happens after the spider dies
            print("Spider Died");
            Destroy(this);
        }
    }
}
