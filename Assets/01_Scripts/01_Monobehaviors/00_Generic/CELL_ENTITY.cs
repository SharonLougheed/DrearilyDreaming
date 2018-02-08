using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[ RequireComponent ( typeof ( NavMeshObstacle ), typeof ( Rigidbody ) ) ]
[ DisallowMultipleComponent ]
public class CELL_ENTITY : MonoBehaviour 
{

	#region --------------------	Public Events

	/// <summary>
	/// Cell events:
	/// On Cell Entity Generate is called whenever the cell entity is told to generate.
	/// </summary>
	public delegate void CELL_ENTITY_EVENT ();
	public event CELL_ENTITY_EVENT On_Cell_Entity_Generate;

	#endregion

	#region --------------------	Public Properties

	/// <summary>
	/// Gets the parent cell.
	/// </summary>
	/// <value>The parent cell.</value>
	public CELL parentCell { get { return _parentCell; } }

	/// <summary>
	/// Gets the audience.
	/// </summary>
	/// <value>The audience.</value>
	public List <NPC> audience { get { return _audience; } }

	/// <summary>
	/// Gets the focal point.
	/// </summary>
	/// <value>The focal point.</value>
	public Vector3 focalPoint { get { return _focalPoint;} }

	#endregion

	#region --------------------	Public Fields

	[ Space ]
	[ Header ( "Entity Configurations" ) ]

	[ Tooltip ( "The chance that this entity will be spawned per cell generation." ) ]
	[ Range ( 0f, 1.0f ) ]
	/// <summary>
	/// The spawn chance.
	/// </summary>
	public float spawnChance = 0.5f;

	[ Space ]
	[ Header ( "Point of Interest Configurations" ) ]

	[ Tooltip ( "Is the entity considered a point of interest for NPCs." ) ]
	/// <summary>
	/// Is the entity a point of interest for NPCs
	/// </summary>
	public bool isPointOfInterest = false;

	#endregion

	#region --------------------	Public Methods

	/// <summary>
	/// Flushs the point of interest.
	/// </summary>
	public void Flush_Point_Of_Interest ()
	{
		if ( isPointOfInterest )
		{
			//	Remove the point of interest if it has already been added
			if ( _parentCell.pointsOfInterest.Contains ( this ) )
			{
				_parentCell.pointsOfInterest.Remove ( this );
			}

			//	Retarget each audience member
			_audience.ForEach ( a => {
				a.Change_Point_Of_Interest ( parentCell.pointsOfInterest [ Random.Range ( 0, _parentCell.pointsOfInterest.Count ) ] );
			} );
		}
	}

	#endregion

	#region --------------------	Protected Methods

	/// <summary>
	/// Recollects the parent information.
	/// </summary>
	protected void Recollect_Parent_Information ()
	{
		if ( _parentEntity != null )
		{
			_parentEntity.On_Cell_Entity_Generate -= Generate;
		}
		else
		{
			_parentCell.On_Cell_Generate -= Generate;
		}

		//	Gather potential sub-entity information and existing cell information
		_parentEntity = transform.parent.GetComponentInParent <CELL_ENTITY> ();
		_parentCell = transform.parent.GetComponentInParent <CELL> ();
		if ( _parentEntity != null )
		{
			//	If the entity is a sub-entity, register with the parent entity
			_parentEntity.On_Cell_Entity_Generate += Generate;
		}
		else
		{
			//	If the entity is not a sub-entity, register with the cell
			_parentCell.On_Cell_Generate += Generate;
		}
	}

	#endregion

	#region --------------------	Private Fields

	/// <summary>
	/// The parent cell.
	/// </summary>
	private CELL _parentCell;

	/// <summary>
	/// The parent entity.
	/// </summary>
	private CELL_ENTITY _parentEntity;

	/// <summary>
	/// The audience of NPCs around the point of interest.
	/// </summary>
	private List <NPC> _audience;

	/// <summary>
	/// The previous audience count.
	/// </summary>
	private int _previousAudienceCount = 0;

	/// <summary>
	/// The focal point.
	/// </summary>
	private Vector3 _focalPoint;

	#endregion

	#region --------------------	Private Methods

	/// <summary>
	/// Start this instance.
	/// </summary>
	private void Start ()
	{
		//	Gather potential sub-entity information and existing cell information
		_parentEntity = transform.parent.GetComponentInParent <CELL_ENTITY> ();
		_parentCell = transform.parent.GetComponentInParent <CELL> ();
		if ( _parentEntity != null )
		{
			//	If the entity is a sub-entity, register with the parent entity
			_parentEntity.On_Cell_Entity_Generate += Generate;
		}
		else
		{
			//	If the entity is not a sub-entity, register with the cell
			_parentCell.On_Cell_Generate += Generate;
		}

		//	Define the audience
		_audience = new List<NPC> ();

		//	Set the tag for the entity
		if ( isPointOfInterest && this.name != "NPC" )
		{
			tag = "Point_Of_Interest";
		}
	}

	/// <summary>
	/// Called at the end of the update frame.
	/// </summary>
	private void LateUpdate ()
	{
		//	If the audience count is different
		if ( _audience.Count != _previousAudienceCount )
		{
			//	Set the previous audience count
			_previousAudienceCount = _audience.Count;

			//	Calculate the new center point as the focal point
			_focalPoint = ( _previousAudienceCount == 1 )? transform.position : Vector3.zero;
			_audience.ForEach ( a => _focalPoint += a.transform.position );
			_focalPoint /= ( _previousAudienceCount + ( ( _previousAudienceCount == 1)? 1 : 0 ) );
		}
	}

	/// <summary>
	/// Generate this instance.
	/// </summary>
	private void Generate ()
	{
		//	Only generate if there is a possibility of not spawning
		if ( spawnChance < 1.0f )
		{
			//	Determine if the entity will be displayed
			bool _gen = ( Random.Range ( 0, 1.0f ) <= spawnChance );

			//	Set the object to active / inactive
			gameObject.SetActive ( _gen );

			//	If the entity is a parent to other entities & it is set to active
			if ( On_Cell_Entity_Generate != null && _gen )
			{
				//	Command its children to generate as well
				On_Cell_Entity_Generate ();
			}

			//	If the object is flagged as a point of interest
			if ( isPointOfInterest )
			{
				//	If it is set to active
				if ( _gen )
				{
					//	Add the point of interest if it is not already added
					if ( !_parentCell.pointsOfInterest.Contains ( this ) )
					{
						_parentCell.pointsOfInterest.Add ( this );
					}
				}
				else
				{
					//	Flushes the point of interest and re-targets all of the audience NPCs
					Flush_Point_Of_Interest ();
				}
			}
		}
	}

	#endregion

}