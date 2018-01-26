using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUSTOM_THIRD_PERSON_CAMERA : MonoBehaviour 
{

	#region --------------------	Public Events

	/// <summary>
	/// Used for tracking when the OnTriggerStay method is called.
	/// </summary>
	public delegate void CAMERA_COLLISION_EVENT ();
	public event CAMERA_COLLISION_EVENT ON_CAMERA_COLLISION_STAY;

	#endregion

	#region --------------------	Private Methods

	/// <summary>
	/// Raises the trigger stay event.
	/// </summary>
	/// <param name="_c">C.</param>
	private void OnTriggerStay ( Collider _c )
	{
		//	If there is a subscriber and the collision is not with the player, reduce the camera distance.
		if ( ON_CAMERA_COLLISION_STAY != null && !_c.CompareTag ( "Player" ) )
		{
			ON_CAMERA_COLLISION_STAY ();
		}
	}

	#endregion

}
