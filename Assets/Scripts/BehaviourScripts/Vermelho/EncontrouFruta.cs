using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncontrouFruta : StateMachineBehaviour
{
    public GameObject[] frutasProximas = null;

    public float range = 20f;
    public float speed = 10f;

    float distance;
    float closest = 20f;
    private Vector3 target;
    public GameObject frutaEscolhida;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector3.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);
        if (Vector3.Distance(animator.transform.position, target) == 0)
        {
            if (frutaEscolhida.GetComponent<Frutas>().livre == true)
                animator.SetBool("carregandoFruta", true);
            else
                animator.SetBool("frutaProxima", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        frutasProximas = GameObject.FindGameObjectsWithTag("Fruta");
        foreach (GameObject fruta in frutasProximas)
        {
            distance = Vector3.Distance(animator.transform.position, fruta.transform.position);
            if (distance < closest)
            {
                target = new Vector3(fruta.transform.position.x, 3, fruta.transform.position.z);
                frutaEscolhida = fruta;
            }
        }
        if(animator.transform.position == target)
        {
            frutaEscolhida.GetComponent<Frutas>().livre = false;
            animator.SetBool("carregandoFruta", true);
            if (animator.CompareTag("AtacanteA"))
            {
                frutaEscolhida.transform.tag = "FrutaAzul";
            }
            else if (animator.CompareTag("AtacanteV"))
            {
                frutaEscolhida.transform.tag = "FrutaVermelha";
            }
        }
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
