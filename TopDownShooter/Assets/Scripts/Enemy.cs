using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent Agent;
    public Player Player;
    public GameObject DeathFX;

    public float AttackRate = 2f;
    public float AttackDistance = 3f;
    public float AttackDamage = 0.1f;
    private float AttackTime = 0f;

    void Update(){
        AttackTime += Time.deltaTime;
        if(AttackTime >= AttackRate)
        {
            AttackTime = 0f;
            Attack();
        }

        Agent.SetDestination(Player.transform.position);
    }

    private void Attack()
    {
        if(Vector3.Distance(Player.transform.position, transform.position) <= AttackDistance)
        {
            Player.Damage(AttackDamage);
        }
    }

    private void OnCollisionEnter(Collision Col){
        if(Col.transform.tag == "Bullet")
        {
            if(DeathFX != null)
            {
                Instantiate(DeathFX, transform.position, transform.rotation);
            }
            Destroy(Col.gameObject);
            Destroy(gameObject);
        }
    }
}
