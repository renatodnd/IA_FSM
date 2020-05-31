using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrulhaAtaque : StateMachineBehaviour
{
    public float speed = 10;
    public float timer = 0;
    public float range = 100f;
    int nfrutas;
    public GameObject[] frutasProximas = null;

    public bool livre = false;
    GameObject baseTime;

    private Vector3 randompos;

    public bool frutaProxima;

    // Start
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        nfrutas = 0;
        randompos = new Vector3(Random.Range(-25, 25), 3, Random.Range(-48, 48));
        if (animator.CompareTag("AtacanteA")) baseTime = GameObject.FindGameObjectWithTag("ColisorA");
        if (animator.CompareTag("AtacanteV")) baseTime = GameObject.FindGameObjectWithTag("ColisorV");
    }

    // Update
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            randompos.x = Random.Range(-25, 25);
            randompos.y = 3;
            randompos.z = Random.Range(-48, 48);
            timer = Random.Range(1,5);
        }
        frutasProximas = GameObject.FindGameObjectsWithTag("Fruta");
        foreach (GameObject fruta in frutasProximas)
        {
            if (Vector3.Distance(fruta.transform.position, animator.transform.position) <=  range)
            {
                if (fruta.GetComponent<Frutas>().livre == true)
                {
                    animator.SetBool("frutaProxima", true);
                    nfrutas++;
                }
            }
        }
        if (nfrutas == 0)
        {
            animator.transform.position = Vector3.MoveTowards(animator.transform.position, randompos, speed * Time.deltaTime);
        }
        if (animator.GetComponent<Collider>().bounds.Intersects(baseTime.GetComponent<Collider>().bounds))
        {
            animator.SetBool("naBase", true);
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
