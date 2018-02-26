using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ RequireComponent ( typeof ( Light ) ) ]
public class CELL_LIGHTING : MonoBehaviour 
{
    #region --------------------    Public Fields
    /// <summary
    /// upper and lower bounds
    /// </summary>
    public float goodRange, badRange;
    #endregion  
    #region --------------------	Private Fields

    /// <summary>
    /// The light.
    /// </summary>
    private Light _light;

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
		_light.color = Color.Lerp ( _light.color, new Color ( 1.0f - Mathf.Clamp ( PlayerNotoriety.GetPlayerNotoriety () / 5.0f, 0, 1.0f ),
			Mathf.Clamp ( 1.0f - Mathf.Abs ( PlayerNotoriety.GetPlayerNotoriety () / goodRange), 0, 1.0f ),
			1.0f - Mathf.Clamp ( PlayerNotoriety.GetPlayerNotoriety () / badRange, 0, 1.0f ) ), Time.deltaTime );
	}

	#endregion

}