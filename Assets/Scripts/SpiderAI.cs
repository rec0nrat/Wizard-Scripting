using UnityEngine;
using System.Collections;

public class SpiderAI : MonoBehaviour 
{
    int health; 
    NavMeshAgent navAgent;

    enum spider_state
    {
        IDOL,
        CHASE,
        ATTACK
    }

    spider_state _spiderState;
    Vector3 playerP;

	// Use this for initialization
	void Start () 
    {
	    navAgent = GetComponent<NavMeshAgent>();
        _spiderState = spider_state.IDOL;
        playerP = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
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
                if (navAgent.CalculatePath(playerP, path))
                {
                    if (navAgent.SetPath(path))
                    {
                        
                    }
                }
            }break;

            case spider_state.ATTACK:
            {
 
            }break; 
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
}
