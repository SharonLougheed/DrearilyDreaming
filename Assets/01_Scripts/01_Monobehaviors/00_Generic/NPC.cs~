using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[ RequireComponent ( typeof ( NavMeshAgent ) ) ]
[ DisallowMultipleComponent ]
public class NPC : MonoBehaviour 
{

	#region --------------------	Public Properties

	/// <summary>
	/// Gets the navmesh agent.
	/// </summary>
	/// <value>The agent.</value>
	public NavMeshAgent agent { get { return _agent; } }

	/// <summary>
	/// Gets the target Point of Interest.
	/// </summary>
	/// <value>The target Point of Interest.</value>
	public POINT_OF_INTEREST targetPOI { get { return _targetPOI; } }

	#endregion

	#region --------------------	Public Fields

	[Space]
	[Header ("Designer Modifications")]
	[Tooltip ("The maximum amount of time (in seconds) an npc will stay at a point of interest.")]
	[Range ( 0f, 90.0f )]
	/// <summary>
	/// The max npc attention span.
	/// </summary>
	public float maxAttentionSpan = 10.0f;

	/// <summary>
	/// The parent cell.
	/// </summary>
	[HideInInspector] public CELL parentCell;

	#endregion

	#region --------------------	Public Methods

	/// <summary>
	/// Selects the point of interest from a list of supplied points.
	/// </summary>
	/// <param name="_pois">Pois.</param>
	public void Select_Point_Of_Interest ( List <POINT_OF_INTEREST> _pois )
	{
		if ( _pois.Count > 0 )
		{
			//	Remove the current target point of interest
			_pois.Remove ( _targetPOI );

			//	Construct a list of weights for each point of interest
			List <int> _weights = new List <int> ();

			//	Populate the list of weights with each appeal from the point of interest
			int _sum = 0;
			_pois.ForEach ( p => {
				_sum += p.appeal;
				_weights.Add ( _sum );
			} );

			//	Select a random value from 0 to the total sum.
			int _n = _weights.IndexOf ( _weights.Find ( w => w >= Random.Range ( 0, _sum ) ) ); 

			//	Find the first weight that is greater than the random value.
			if ( _n != -1 )
			{
				_targetPOI = _pois [ _n ];
				_agent.SetDestination ( _targetPOI.transform.position );
			}

			//	No longer idling
			_isIdling = false;
		}
		else
		{

		}
	}

	/// <summary>
	/// Called when the npc arrives at a point of interest.
	/// </summary>
	public IEnumerator Idle ()
	{
		//	Set idling to true
		_isIdling = true;

		//	Determine how long the npc will stay.
		_attentionSpan = Random.Range ( 0f, maxAttentionSpan );

		//	Wait until the time is up
		yield return new WaitForSeconds ( _attentionSpan );

		//	Select a new point of interest and begin travelling there
		Select_Point_Of_Interest ( parentCell.pointsOfInterest );
	}

	/// <summary>
	/// Looks at the supplied focal point.
	/// </summary>
	/// <param name="_focalPoint">Focal point.</param>
	public void Look_At_Focal_Point ( Vector3 _focalPoint )
	{
		_agent.transform.LookAt ( _focalPoint, Vector3.up );
	}

	#endregion

	#region --------------------	Private Fields

	/// <summary>
	/// The attached navmesh agent.
	/// </summary>
	private NavMeshAgent _agent;

	/// <summary>
	/// How long an NPC will stay at a particular point of interest.
	/// </summary>
	private float _attentionSpan;

	/// <summary>
	/// Used to eval whether or not the npc is idling.
	/// </summary>
	private bool _isIdling = false;

	/// <summary>
	/// The target Point of Interest.
	/// </summary>
	private POINT_OF_INTEREST _targetPOI;

	#endregion

	#region --------------------	Private Methods

	/// <summary>
	/// Awake this instance.
	/// </summary>
	private void Awake ()
	{
		_agent = GetComponent <NavMeshAgent> ();
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	private void Update ()
	{
		//	If idling, look at the focal point of the point of interest
		if ( _isIdling )
		{
			Vector3 _lookPosition = Vector3.Slerp ( transform.position + transform.forward, _targetPOI.focalPoint, Time.deltaTime );
			_lookPosition.y = transform.position.y;
			transform.LookAt ( _lookPosition );
		}
	}

	#endregion

}