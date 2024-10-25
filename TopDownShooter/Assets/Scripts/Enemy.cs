using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Transform Player;
    public GameObject DeathFX;

    void Update(){
        Agent.SetDestination(Player.position);
    }

    private void OnCollisionEnter(Collision Col){
        if(Col.transform.tag == "Bullet"){

            if(DeathFX != null)
            {
                Instantiate(DeathFX, transform.position, transform.rotation);
            }

            Destroy(Col.gameObject);
            Destroy(gameObject);
        }
    }
}
