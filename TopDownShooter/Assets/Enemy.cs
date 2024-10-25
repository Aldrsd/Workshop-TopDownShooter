using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Transform Player;

    void Update(){
        Agent.SetDestination(Player.position);
    }
    private void OnCollisionEnter(Collision Col){
        if(Col.gameObject.CompareTag("Bullet")){
            Destroy(Col.gameObject);
            Destroy(gameObject);
        }
    }
}
