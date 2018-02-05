//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;
//
//[ RequireComponent ( typeof ( NavMeshObstacle ) ) ]
//public class ENTITY_TABLE : CELL_ENTITY 
//{
//
//	#region --------------------	Public Properties
//
//	public POINT_OF_INTEREST currentPointOfInterest { get { return _currentPointOfInterest; } }
//
//	#endregion
//
//	#region --------------------	Public Methods
//
//	/// <summary>
//	/// Randomly sets up the table.
//	/// </summary>
//	public void Setup_Table ()
//	{
//		//	Grab all of the attached points of interest
//		_pointsOfInterest = new List <POINT_OF_INTEREST> ( GetComponentsInChildren <POINT_OF_INTEREST> () );
//
//		//	Grab all of the attached gameobjects with colliders
//		_attachedItems = new List <Collider> ( GetComponentsInChildren <Collider> () );
//
//		//	Iterate through all of the attached colliders and randomly set them to active / inactive
//		_attachedItems.ForEach ( i => i.gameObject.SetActive ( ( i.gameObject.name != gameObject.name )? Random.Range ( 0, 2 ) > 0 : i.gameObject.activeSelf ) );
//
//		//	Disable all points of interest
//		_pointsOfInterest.ForEach ( p => p.gameObject.SetActive ( false ) );
//
//		//	Activate a random point of interest
//		int _r = Random.Range ( 0, _pointsOfInterest.Count );
//		_pointsOfInterest [ _r ].gameObject.SetActive ( true );
//
//		//	Set current point of interest
//		_currentPointOfInterest = _pointsOfInterest [ _r ];
//	} 
//
//	#endregion
//
//	#region --------------------	Private Fields
//
//	/// <summary>
//	/// The list of poi objects attached to the table.
//	/// </summary>
//	private List <POINT_OF_INTEREST> _pointsOfInterest;
//
//	/// <summary>
//	/// The list of all attached items on the table.
//	/// </summary>
//	private List <Collider> _attachedItems;
//
//	/// <summary>
//	/// The current point of interest.
//	/// </summary>
//	private POINT_OF_INTEREST _currentPointOfInterest;
//
//	#endregion
//
//}
