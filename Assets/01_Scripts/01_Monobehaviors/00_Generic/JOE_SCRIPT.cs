using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JOE_SCRIPT : MonoBehaviour 
{

	private NPC _npc;
	[SerializeField] private List <Transform> _spawns;

	// Use this for initialization
	void Start () {
		_npc = GetComponent <NPC> ();
		_npc.agent.Warp ( _spawns [ Random.Range ( 0, _spawns.Count ) ].position );
	}

}