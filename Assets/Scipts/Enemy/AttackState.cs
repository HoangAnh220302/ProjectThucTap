using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private float moveTimer;
    private float losePlayerTimer;
    public override void Enter()
    {
         
    }
    public override void Performed()
    {
        if(enemy.CanSeePlayer())
        {
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            if(moveTimer > Random.RandomRange(3,7))
            {
                //move enemy
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
            }
            else
            {
                losePlayerTimer += Time.deltaTime;
                if(losePlayerTimer > 8)
                {
                    stateMachine.ChangeState(new PatrolState());
                    //change to search state
                }
            }
        }
    }
    public override void Exit()
    {
        
    }

    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
