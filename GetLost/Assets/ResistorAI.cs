﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ResistorAI : MonoBehaviour {

	public Transform player;
	public float scoutRange;

	private NavMeshAgent agent;
	private Vector3 distance;


	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {

		distance = player.position - this.transform.position;

		if (Mathf.Abs (distance.magnitude) <= scoutRange) {
			if (Mathf.Abs (distance.magnitude) >= 3) {
				agent.isStopped = false;
				agent.SetDestination (player.position + distance.normalized * 2);
			} else {
				agent.isStopped = true;
				this.transform.Rotate (0, 10, 0);
				player.GetComponent<Character> ().LoseEletricCharge(1 * Time.deltaTime);
			}
		}


	
	}
}
