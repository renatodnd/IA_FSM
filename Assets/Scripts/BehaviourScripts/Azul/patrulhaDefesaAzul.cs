using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrulhaDefesaAzul : StateMachineBehaviour
{
    public Transform defensor;

    public float speed = 10f;
    private Vector3 randompos;
    public float timer = 0f;

    //Start
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        randompos = new Vector3(Random.Range(-25, 25), 3, Random.Range(-48, 48));
    }

    // Update
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            randompos.x = Random.Range(-25f, 25f);
            randompos.y = 3f;
            randompos.z = Random.Range(-48f, 48f);
            timer = 3f;
        }
        animator.transform.position = Vector3.MoveTowards(animator.transform.position, randompos, speed * Time.deltaTime);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
