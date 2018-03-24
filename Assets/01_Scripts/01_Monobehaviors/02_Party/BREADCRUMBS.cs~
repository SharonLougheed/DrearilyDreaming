using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BREADCRUMBS : MonoBehaviour 
{

	private List <ParticleSystem> _crumbs;

	[ SerializeField ] private Transform _target;

	private int _index = 0;

	private void Start ()
	{
		_crumbs = new List <ParticleSystem> ( GetComponentsInChildren <ParticleSystem> () );
		StartCoroutine ( Drop_Breadcrumb () );
	}

	private IEnumerator Drop_Breadcrumb ()
	{
		yield return new WaitForSeconds ( 1f );
		_crumbs [ _index ].Clear ();
		_crumbs [ _index ].transform.position = _target.position;
		_crumbs [ _index ].transform.parent = _target.parent;
		_crumbs [ _index ].transform.localScale = new Vector3 ( 0.07f, 0.07f, 0.07f );
		_crumbs [ _index ].Play ();
		_index = ( _index < _crumbs.Count - 1 ) ? _index + 1 : 0;
		StartCoroutine ( Drop_Breadcrumb () );
	}

}
