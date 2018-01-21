using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[ DisallowMultipleComponent ]
public class CELL : MonoBehaviour 
{

	#region --------------------	Public Properties

	/// <summary>
	/// Gets the cell position in relation to the larger cell map.
	/// </summary>
	/// <value>The cell position.</value>
	public Vector2 cellPosition { get { return new Vector2 ( transform.position.x / 100 , transform.position.z / 100 ); } }

	/// <summary>
	/// Gets the active points of interest in the cell.
	/// </summary>
	/// <value>The points of interest.</value>
	public List <POINT_OF_INTEREST> pointsOfInterest { get { return _pointsOfInterest; } }

	/// <summary>
	/// Gets the npc spawn points.
	/// </summary>
	/// <value>The npc spawn points.</value>
	public List <GameObject> npcSpawnPoints { get { return _npcSpawnPoints; } }

	#endregion

	#region --------------------	Public Fields

	[Space]
	[Header ("Designer Modifications")]
	[Tooltip ("The chance that each individual table will be generated.")]
	[Range (0f, 1.0f)]
	/// <summary>
	/// The chance that an individual table will be generated.
	/// </summary>
	public float tableChance = 0.5f;

	[Tooltip ("The chance that each individual balloon group will be generated.")]
	[Range (0f, 1.0f)]
	/// <summary>
	/// The chance that an individual balloon group will be generated.
	/// </summary>
	public float balloonChance = 0.5f;

	#endregion

	#region --------------------	Public Methods

	/// <summary>
	/// Generates a new cell if it is not within the character's 1 cell radius.
	/// </summary>
	public void Generate_Cell ()
	{
		_pointsOfInterest.Clear ();
		_entities.ForEach ( e => { 
			//	If the entity is a table
			if ( e.GetType () == typeof ( ENTITY_TABLE ) )
			{
				//	Roll to see if the table will be set active
				if ( Random.Range ( 0f, 1.0f ) <= tableChance )
				{
					//	If the roll is successful, activate the table and set up a random configuration
					e.gameObject.SetActive ( true );
					( ( ENTITY_TABLE ) e).Setup_Table ();
					_pointsOfInterest.Add ( ( ( ENTITY_TABLE ) e).currentPointOfInterest );
				}
				else
				{
					//	If the roll is unsuccessful, deactivate the table
					e.gameObject.SetActive ( false );
				}
			}
			else
			{
				//	If the entity is a balloon, roll to see if it will be activated or deactivated
				e.gameObject.SetActive ( Random.Range ( 0f, 1.0f ) <= balloonChance ) ;
			}
		} );
	}

	/// <summary>
	/// Spawns all of the party goers randomly across all of the cell's available spawn points.
	/// </summary>
	public void Spawn_NPCs ()
	{
		_partyGoers.ForEach ( p => {
			//	Technically, not spawning.
			//	Simply move the npc to a spawn point and give them a new point of interest
			p.transform.position = _npcSpawnPoints [ Random.Range ( 0, _npcSpawnPoints.Count ) ].transform.position;
			p.parentCell = this;
			p.Select_Point_Of_Interest ( pointsOfInterest );
		} );
	}

	/// <summary>
	/// Translate the cell by the specified _offset.
	/// </summary>
	/// <param name="_offset">Offset.</param>
	public void Translate ( Vector3 _offset )
	{
		//	Stop synchronizing navmesh simulated position with transform position
		_partyGoers.ForEach ( p => {
			p.agent.updatePosition = false;
		} );

		//	Move the cell
		transform.position += _offset;

		//	Restart synchronizing navmesh simulated position with transform position
		_partyGoers.ForEach ( p => {
			//	Move navmesh to transform point
			p.agent.Warp ( p.transform.position );
			p.agent.updatePosition = true;
			p.agent.SetDestination ( p.targetPOI.transform.position );
		} );
	}

	#endregion

	#region --------------------	Private Fields

	[Space]
	[Tooltip ("The list of all people to spawn in the party")]
	/// <summary>
	/// The npcs at the party.
	/// </summary>
	[SerializeField] private List <NPC> _partyGoers;

	[Tooltip ("The list of all available spawn points for the party goers")]
	/// <summary>
	/// The npc spawn points.
	/// </summary>
	[SerializeField] private List <GameObject> _npcSpawnPoints;

	[Tooltip ("The list of all of the entities in the party scene")]
	/// <summary>
	/// The entity instances in the scene.
	/// </summary>
	[SerializeField] private List <ENTITY> _entities;

	/// <summary>
	/// The list of points of interest.
	/// </summary>
	private List <POINT_OF_INTEREST> _pointsOfInterest;

	#endregion

	#region --------------------	Private Methods

	/// <summary>
	/// Awake this instance.
	/// </summary>
	private void Awake ()
	{
		_pointsOfInterest = new List <POINT_OF_INTEREST> ( GetComponentsInChildren <POINT_OF_INTEREST> ( false ) );
	}

	/// <summary>
	/// Testing
	/// </summary>
	private void Start ()
	{
		//	Generate the cell layout
		Generate_Cell ();

		//	Spawn the cell's NPCs
		Spawn_NPCs ();

		//	Register with the map
		Register_Cell_With_Map ();
	}

	/// <summary>
	/// Raises the destroy event.
	/// </summary>
	private void OnDestroy ()
	{
		if ( CELL_MAP.cellInstances.Count > 0 )
		{
			CELL_MAP.cellInstances.Clear ();
		}
	}

	/// <summary>
	/// Registers the cell instance with the map in order by position ( left to right, top to bottom ).
	/// </summary>
	private void Register_Cell_With_Map ()
	{
		//	Keep track to see when / if the cell instance is added to the map
		bool _isAdded = false;
		for ( int c = 0; c < CELL_MAP.cellInstances.Count; c++ )
		{
			//	If the y position is greater than the current cell
			if ( cellPosition.y > CELL_MAP.cellInstances [ c ].cellPosition.y )
			{
				//	If the x position is greater than the current cell
				if ( cellPosition.x < CELL_MAP.cellInstances [ c ].cellPosition.x )
				{
					//	Insert the cell into the map at the current position and break
					CELL_MAP.cellInstances.Insert ( c, this );
					_isAdded = true;
					break;
				}
			}
		}
		//	If the cell was not inserted into the map, add it to the end of the map
		if ( !_isAdded )
		{
			CELL_MAP.cellInstances.Add ( this );
		}
	}

	#endregion

}