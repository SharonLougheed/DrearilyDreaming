using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOOTPRINTS_OUT : MonoBehaviour 
{

	[ SerializeField ] private Transform _follow;
	[ SerializeField ] private Transform _target;
	public static bool visible = false;
	private Material _material;

	void Start ()
	{
		_material = GetComponent <MeshRenderer> ().material;
	}

	// Update is called once per frame
	void Update ()
	{
		_material.SetFloat ( "_Opacity", Mathf.Clamp ( _material.GetFloat ( "_Opacity" ) + ( Time.deltaTime * ( ( visible )? 1f : -1f ) ) , 0f, 1f ) );
		if ( !visible && _material.GetFloat ( "_Opacity" ) == 0f )
		{
			transform.LookAt ( _target, Vector3.up );
			transform.rotation = Quaternion.Euler ( new Vector3 ( 0f, transform.rotation.eulerAngles.y + 180f, 0f ) );
			transform.position = new Vector3 ( _follow.position.x, 0.2f, _follow.position.z );
		}
	}

}