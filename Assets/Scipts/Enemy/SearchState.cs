
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : BaseState
{
    private float searchTimer;
    private float moveTimer;
    public override void Enter()
    {
        //enemy moves to player's last position
        enemy.Agent.SetDestination(enemy.LastKnownPos);
    }
    public override void Performed()
    {
        //check if enemy sees he player again
        if(enemy.CanSeePlayer())
        {
            stateMachine.ChangeState(new AttackState());
        }
        //if enemy arrived at player's last position
        if(enemy.Agent.remainingDistance < enemy.Agent.stoppingDistance)
        {
            //search for a rand amount of time
            searchTimer += Time.deltaTime;
            moveTimer += Time.deltaTime;
            if (moveTimer > Random.Range(3, 5))
            {
                //move enemy
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 10));
                moveTimer = 0;
            }
            if (searchTimer > 10)
            {
                stateMachine.ChangeState(new PatrolState());
            }
        }
    }
    public override void Exit()
    {
        
    }
}
