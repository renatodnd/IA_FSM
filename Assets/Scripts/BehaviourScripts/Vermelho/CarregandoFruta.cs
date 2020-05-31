using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarregandoFruta : StateMachineBehaviour
{
    public GameObject fruta;
    public GameObject baseTime;
    public float speed = 8f;
    public int pontos = 0;
    public Collision colisor;
    float timer;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 3f;
        if (animator.CompareTag("AtacanteA"))
        {
            Debug.Log("Azul");
            baseTime = GameObject.FindGameObjectWithTag("BaseA");
            fruta = GameObject.FindGameObjectWithTag("FrutaAzul");
        }
        else if (animator.CompareTag("AtacanteV"))
        {
            Debug.Log("Vermelho");
            baseTime = GameObject.FindGameObjectWithTag("BaseV");
            fruta = GameObject.FindGameObjectWithTag("FrutaVermelha");
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        fruta.transform.position = Vector3.MoveTowards(fruta.transform.position, new Vector3(animator.transform.position.x, animator.transform.position.y + 3f, animator.transform.position.z), 1000);
        animator.transform.position = Vector3.MoveTowards(animator.transform.position, new Vector3(baseTime.transform.position.x, 3f, baseTime.transform.position.y), speed * Time.deltaTime);
        if (animator.GetComponent<Collider>().bounds.Intersects(baseTime.GetComponent<Collider>().bounds))
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                animator.SetBool("naBase", true);
                Destroy(fruta);
                animator.SetBool("carregandoFruta", false);
                pontos++;
            }
        }
        else
        {
            animator.SetBool("naBase", false);
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
