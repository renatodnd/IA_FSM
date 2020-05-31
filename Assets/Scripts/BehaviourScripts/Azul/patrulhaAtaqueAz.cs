using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrulhaAtaqueAz : StateMachineBehaviour
{
    public float speed = 10;
    public float timer = 0;
    public float range = 10f;
    int nfrutas;
    public GameObject[] frutasProximas = null;

    public bool livre = false;


    private Vector3 randompos;

    public bool frutaProxima;

    // Start
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        nfrutas = 0;
        randompos = new Vector3(Random.Range(-25, 25), 3, Random.Range(-48, 48));
    }

    // Update
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        frutasProximas = GameObject.FindGameObjectsWithTag("Fruta");
        timer -= Time.deltaTime;
        
        foreach (GameObject fruta in frutasProximas)
        {
            if (Vector3.Distance(fruta.transform.position, animator.transform.position) < range)
            {
                if (fruta.GetComponent<Frutas>().livre == true)
                {
                    nfrutas++;
                    animator.transform.position = Vector3.MoveTowards(animator.transform.position, new Vector3(Random.Range(-25, 25), 3, Random.Range(-48, 48)), speed * Time.deltaTime);
                    animator.SetBool("frutaProxima", true);
                }
            }
        }
        if (timer <= 0)
        {
            randompos.x = Random.Range(-25f, 25f);
            randompos.y = 3f;
            randompos.z = Random.Range(-48f, 48f);
            timer = 3f;
        }
        if (nfrutas == 0)
        {
            animator.transform.position = Vector3.MoveTowards(animator.transform.position, randompos, speed * Time.deltaTime);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}

    //OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
