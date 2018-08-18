using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehavior : StateMachineBehaviour
{

    private PatrolSpots patrol;
    public float speed;
    private int randomSpot;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        patrol = GameObject.FindGameObjectWithTag("PatrolSpots").GetComponent<PatrolSpots>();
        randomSpot = Random.Range(0, patrol.patrolPoints.Length);
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(animator.transform.position, patrol.patrolPoints[randomSpot].position) > 0.2f)
        {
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, patrol.patrolPoints[randomSpot].position, speed * Time.deltaTime);

        }
        else
        {
            randomSpot = Random.Range(0, patrol.patrolPoints.Length);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            animator.SetBool("isPatrolling", false);
        }

    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
