using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ RequireComponent ( typeof ( Light ) ) ]
public class CELL_LIGHTING : MonoBehaviour 
{
    #region --------------------    Public Fields


    #endregion  

    #region --------------------	Private Fields

    /// <summary>
    /// The light.
    /// </summary>
    private Light _light;


	[ Range ( 0f, 1f ) ]
	/// <summary>
	/// The impact that the noteriety has on the color of the lighting.
	/// </summary>
	[ SerializeField ] private float _noterietyImpact = 0.7f;

	#endregion

	#region --------------------	Private Methods

	/// <summary>
	/// Awake this instance.
	/// </summary>
	private void Awake ()
	{
		_light = GetComponent <Light> ();
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	private void Update ()
	{
		_light.color = Color.Lerp ( _light.color, new Color ( 1f - Mathf.Clamp ( PlayerNotoriety.GetPlayerNotoriety () / ( ( 1.001f - _noterietyImpact ) * 5f ), 0, 1f ),
			Mathf.Clamp ( 1.0f - Mathf.Abs ( PlayerNotoriety.GetPlayerNotoriety () / ( ( 1.001f - _noterietyImpact ) * 5f ) ), 0, 1f ),
			1f - Mathf.Clamp ( PlayerNotoriety.GetPlayerNotoriety () / ( ( 1.001f - _noterietyImpact ) * -5f ), 0, 1f ) ), Time.deltaTime );
	}

	#endregion

}