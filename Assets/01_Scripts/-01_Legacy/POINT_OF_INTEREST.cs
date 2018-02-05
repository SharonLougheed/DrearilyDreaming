//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;
//
//[ DisallowMultipleComponent ]
//public class POINT_OF_INTEREST : MonoBehaviour 
//{
//
//	#region --------------------	Public Properties
//
//	/// <summary>
//	/// Gets the focal point.
//	/// </summary>
//	/// <value>The focal point.</value>
//	public Vector3 focalPoint { get { return _focalPoint; } }
//
//	/// <summary>
//	/// Gets the appeal of the focal point to the npcs.
//	/// </summary>
//	/// <value>The appeal.</value>
//	public int appeal { get { return _npcs.Count + 1; } }
//
//	#endregion
//
//	#region --------------------	Public Fields
//
//	[Space]
//	[Tooltip ("Determines the type of the point of interest for npc interaction")]
//	/// <summary>
//	/// The type of the point of interest.
//	/// </summary>
//	public POI_TYPE pointOfInterestType = POI_TYPE.EMPTY;
//
//	#endregion
//
//	#region --------------------	Private Fields
//
//	/// <summary>
//	/// The focal point for the npcs at the point of interest.
//	/// </summary>
//	private Vector3 _focalPoint = Vector3.zero;
//
//	/// <summary>
//	/// The npcs at the point of interest.
//	/// </summary>
//	private List <GameObject> _npcs = new List <GameObject> ();
//
//	#endregion
//
//	#region --------------------	Private Methods
//
//	/// <summary>
//	/// Raises the trigger enter event.
//	/// </summary>
//	/// <param name="other">Other.</param>
//	private void OnTriggerEnter ( Collider other )
//	{
//		if ( other.CompareTag ( "NPC" ) )
//		{
//			//	If the npc is coming to this point of interest
//			if ( other.GetComponent <NPC> ().targetPOI == this )
//			{
//				//	Stop the npc
//				other.GetComponent <NavMeshAgent> ().SetDestination ( other.transform.position );
//
//				//	Register the new npc and update the focal point
//				_npcs.Add ( other.gameObject );
//				Update_Focal_Point ();
//
//				//	Have the npc begin idling
//				StartCoroutine ( other.GetComponent <NPC> ().Idle () );
//			}
//		}
//	}
//
//	/// <summary>
//	/// Raises the trigger enter exit.
//	/// </summary>
//	/// <param name="other">Other.</param>
//	private void OnTriggerExit ( Collider other )
//	{
//		if ( other.CompareTag ( "NPC" ) )
//		{
//			//	If the npc was stopped at this point of interest
//			if ( _npcs.Contains ( other.gameObject ) )
//			{
//				//	Deregister the old npc and update the focal point
//				_npcs.Remove ( other.gameObject );
//				Update_Focal_Point ();
//			}
//		}
//	}
//
//	/// <summary>
//	/// Updates the focal point.
//	/// </summary>
//	private void Update_Focal_Point ()
//	{
//		//	Reset the focal point to the item's position
//		_focalPoint = transform.position;
//
//		//	Add the locations for each local npc
//		_npcs.ForEach ( n => {
//			_focalPoint.x += n.transform.position.x;
//			_focalPoint.z += n.transform.position.z;
//		} );
//
//		//	Find the average of all of the locations
//		_focalPoint.x /= _npcs.Count + 1;
//		_focalPoint.z /= _npcs.Count + 1;
//	}
//
//	#endregion
//
//}
