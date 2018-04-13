using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JOE_SCRIPT : MonoBehaviour 
{

	private NPC _npc;
	[SerializeField] private List <Transform> _spawns;
	private bool _hasFired = false;

	// Use this for initialization
	void LateUpdate () {
		if ( !_hasFired )
		{
			_hasFired = true;
			_npc = GetComponent <NPC> ();
			_npc.agent.Warp ( _spawns [ Random.Range ( 0, _spawns.Count ) ].position );
		}
	}

}