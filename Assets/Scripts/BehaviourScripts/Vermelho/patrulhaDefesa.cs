using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrulhaDefesa : StateMachineBehaviour
{
    public Transform defensor;

    public float speed = 10f, timer = 0f, range = 1000f;
    private Vector3 randompos;
    GameObject fruta, atacante;

    //Start
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        randompos = new Vector3(Random.Range(-25, 25), 3, Random.Range(-48, 48));
        if (animator.CompareTag("DefensorA"))
        {
            Debug.Log("Azul");
            atacante = GameObject.FindGameObjectWithTag("AtacanteV");
        }
        if (animator.CompareTag("DefensorV"))
        {
            Debug.Log("Vermelho");
            atacante = GameObject.FindGameObjectWithTag("AtacanteA");
        }
    }

    // Update
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer -= Time.deltaTime;
        if (animator.CompareTag("DefensorA"))
        {
            fruta = GameObject.FindGameObjectWithTag("FrutaVermelha");
        }
        if (animator.CompareTag("DefensorV"))
        {
            fruta = GameObject.FindGameObjectWithTag("FrutaAzul");
        }
        if (timer <= 0)
        {
            randompos.x = Random.Range(-25f, 25f);
            randompos.y = 3f;
            randompos.z = Random.Range(-48f, 48f);
            timer = Random.Range(1, 5);
        }
        animator.transform.position = Vector3.MoveTowards(animator.transform.position, randompos, speed * Time.deltaTime);
        if (Vector3.Distance(atacante.transform.position, animator.transform.position) < range)
        {  
            if (atacante.GetComponent<Animator>().GetBool("carregandoFruta") == true)
            {
                animator.SetBool("viuAdversario", true);
                if (fruta.GetComponent<Frutas>().livre == false)
                {
                    animator.SetBool("frutaAdversario", true);
                }
                else
                {
                    animator.SetBool("frutaAversario", false);
                }
            }
            else
            {
                animator.SetBool("viuAdversario", false);
            }
        }
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
