using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ RequireComponent ( typeof ( AudioSource ) ) ]
public class CELL_STEREO : MonoBehaviour 
{

	#region --------------------	Public Properties

	/// <summary>
	/// Gets the instance.
	/// </summary>
	/// <value>The instance.</value>
	public static CELL_STEREO instance { get { return _this; } }

	#endregion

	#region --------------------	Public Fields

	/// <summary>
	/// The target.
	/// </summary>
	public NPC target;

	#endregion

	#region --------------------	Public Methods

	/// <summary>
	/// Toggles the mute.
	/// </summary>
	public void ToggleMute ()
	{
		_audio.volume = ( _audio.volume > 0 ) ? 0 : 1.0f;
		if ( _audio.volume > 0 )
		{
			PlayerNotoriety.IncreasePlayerNotoriety ();
		}
		else
		{
			PlayerNotoriety.DecreasePlayerNotoriety ();
		}
	}

	/// <summary>
	/// Translate by the specified _direction.
	/// </summary>
	/// <param name="_direction">Direction.</param>
	public void Translate ( Vector3 _direction )
	{
		transform.position += _direction;
	}

	#endregion

	#region --------------------	Private Fields

	/// <summary>
	/// The audio.
	/// </summary>
	private AudioSource _audio;

	/// <summary>
	/// This
	/// </summary>
	private static CELL_STEREO _this;

	#endregion

	#region --------------------	Private Methods

	/// <summary>
	/// Awake this instance.
	/// </summary>
	private void Awake ()
	{
		_audio = GetComponent <AudioSource> ();
		if ( _this == null )
		{
			_this = this;
		}
		else
		{
			Destroy ( this );
		}
	}

	// Update is called once per frame
	private void LateUpdate () 
	{
//		if ( ( target.transform.position - transform.position ).magnitude >= 50.0f )
//		{
//			transform.position = target.position * 100.0f;
//		}
//		else
//		{
			transform.position = Vector3.Slerp ( transform.position, target.position * 100.0f, Time.deltaTime * 0.1f );
//		}
	}
		
	#endregion

}