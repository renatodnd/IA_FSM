using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perseguirAtacante : StateMachineBehaviour
{
    public float speed = 10f;
    float range = 1000f;
    public float timer;
    public GameObject atacante;
    public GameObject fruta;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 5f;
        if (animator.CompareTag("DefensorA"))
        {
            atacante = GameObject.FindGameObjectWithTag("AtacanteV");
            fruta = GameObject.FindGameObjectWithTag("FrutaVermelha");
        }
        else if (animator.CompareTag("DefensorV"))
        {
            atacante = GameObject.FindGameObjectWithTag("AtacanteA");
            fruta = GameObject.FindGameObjectWithTag("FrutaAzul");
        }
    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector3.MoveTowards(animator.transform.position, atacante.transform.position, speed * Time.deltaTime);
        if (Vector3.Distance(animator.transform.position, atacante.transform.position) <= range)
        {
            if (Vector3.Distance(animator.transform.position, atacante.transform.position) < 30f)
            {
                timer -= Time.deltaTime;
            }
            if (timer <= 0)
            {
                Destroy(fruta);
                atacante.GetComponent<Animator>().SetBool("frutaProxima", false);
                atacante.GetComponent<Animator>().SetBool("carregandoFruta", false);
                animator.SetBool("viuAdversario", false);
                animator.SetBool("frutaAversario", false);
            }
        }
        if(Vector3.Distance(animator.transform.position, atacante.transform.position) > range)
        {
            animator.SetBool("viuAdversario", false);
        }
        if (fruta == null)
        {
            animator.SetBool("frutaAversario", false);
        }
        if(atacante.GetComponent<Animator>().GetBool("carregandoFruta") == false)
        {
            animator.SetBool("viuAdversario", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
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
