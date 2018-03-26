using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOOTPRINTS : MonoBehaviour 
{

	#region --------------------	Public Properties

	/// <summary>
	/// Gets the material.
	/// </summary>
	/// <value>The material.</value>
	public Material material { get { return _footprintMaterial; } }

	#endregion

	#region --------------------	Private Fields

	[ SerializeField ] private Material _footprintMaterial;

	[ Range ( 0f, 1f ) ]
	/// <summary>
	/// The impact that the noteriety has on the color of the lighting.
	/// </summary>
	[ SerializeField ] private float _noterietyImpact = 0.7f;

	#endregion

	#region --------------------	Private Methods

	// Update is called once per frame
	private void Update () {
		_footprintMaterial.color = Color.Lerp ( _footprintMaterial.color, new Color ( 1f - Mathf.Clamp ( PlayerNotoriety.GetPlayerNotoriety () / ( ( 1.001f - _noterietyImpact ) * 5f ), 0, 1f ),
			Mathf.Clamp ( 1.0f - Mathf.Abs ( PlayerNotoriety.GetPlayerNotoriety () / ( ( 1.001f - _noterietyImpact ) * 5f ) ), 0, 1f ),
			1f - Mathf.Clamp ( PlayerNotoriety.GetPlayerNotoriety () / ( ( 1.001f - _noterietyImpact ) * -5f ), 0, 1f ) ), Time.deltaTime );
	}

	#endregion

}