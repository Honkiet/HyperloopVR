using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour {

	GameObject[] goalLocations;
	UnityEngine.AI.NavMeshAgent agent;
	Animator animator;

	// Use this for initialization
	void Start () {
		goalLocations = GameObject.FindGameObjectsWithTag("goal");
		agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
		agent.SetDestination(goalLocations[Random.Range(0,goalLocations.Length)].transform.position);
		animator = this.GetComponent<Animator>();
		animator.SetFloat("walkOffset", Random.Range(0,1f));
		animator.SetTrigger("isWalking");
		float speedMulti = Random.Range(0.5f, 1);
		animator.SetFloat("speedMultiplier", speedMulti);
		//agent.speed *= speedMulti;
	}
	
	// Update is called once per frame
	void Update () {
		if(agent.remainingDistance < 1)
        {
			agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
        }
			
	}
}
