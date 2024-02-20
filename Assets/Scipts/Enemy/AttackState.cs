using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private float moveTimer;
    private float losePlayerTimer;
    private float shootTimer;

    public override void Enter()
    {
         
    }
    public override void Performed()
    {
        if(enemy.CanSeePlayer()) //player can be seen
        {
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            shootTimer += Time.deltaTime;
            enemy.transform.LookAt(enemy.Player.transform);
            if (shootTimer > enemy.fireRate)
            {
                Shoot();
            }
            if(moveTimer > Random.Range(3,7))
            {
                //move enemy
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                moveTimer = 0;
            }
            enemy.LastKnownPos = enemy.Player.transform.position;
        }
        else //lost sight of player
        {
            losePlayerTimer += Time.deltaTime;
            if (losePlayerTimer > 8)
            {
                //change to search state
                stateMachine.ChangeState(new SearchState());
                
            }
        }
    }
    public void Shoot()
    {
        //store a reference to the gun barrel
        Transform gunbarrel = enemy.gunBarrel;
        Transform enemyTransform = enemy.transform;
        //crate a new bullet
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet") as GameObject, gunbarrel.position, enemyTransform.rotation);
        //calculate the direction to the player
        Vector3 shootDirection = (enemy.Player.transform.position - gunbarrel.transform.position).normalized;
        //add force rigidbody of the bullet;
        bullet.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(Random.Range(-3f, 3f), Vector3.up) * shootDirection * 40; //speed
        
        //Debug.Log("Shoot");
        shootTimer = 0;
    }
    public override void Exit()
    {
        
    }
}
