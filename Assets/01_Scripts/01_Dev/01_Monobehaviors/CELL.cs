using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CELL : MonoBehaviour 
{

	#region --------------------	Public Properties

	/// <summary>
	/// Gets the cell position in relation to the larger cell map.
	/// </summary>
	/// <value>The cell position.</value>
	public Vector2 cellPosition { get { return new Vector2 ( transform.position.x / 100 , transform.position.z / 100 ); } }

	#endregion

	#region --------------------	Public Fields

	[Space]
	[Header ("Designer Mods")]
	/// <summary>
	/// The odds that a table will be set to active.
	/// </summary>
	[Range ( 0, 1 )]
	public float tableChance = 0.5f;

	/// <summary>
	/// The odds that a balloon will be set to active.
	/// </summary>
	[Range ( 0, 1 )]
	public float balloonChance = 0.5f;

	/// <summary>
	/// The odds that an npc group will be set to active.
	/// </summary>
	[Range ( 0, 1 )]
	public float npcChance = 0.5f;

	#endregion

	#region --------------------	Public Methods

	/// <summary>
	/// Generates a new cell if it is not within the character's 1 cell radius.
	/// </summary>
	public void Generate_Cell ()
	{
		//	Iterate through each child table and randomly determine if it should be set to active or inactive
		_tables.ForEach ( t => t.SetActive ( Random.Range ( 0f, 1.0f ) <= tableChance ) );

		//	Iterate through each child balloon and randomly determine if it should be set to active or inactive
		_balloons.ForEach ( b => b.SetActive ( Random.Range ( 0f, 1.0f ) <= balloonChance ) );

		//	Iterate through each child npc group and randomly determine if it should be set to active or inactive
		_npcs.ForEach ( n => n.SetActive ( Random.Range ( 0f, 1.0f ) <= npcChance ) );
	}

	#endregion

	#region --------------------	Private Fields

	[Space]
	[Header ("References")]
	/// <summary>
	/// The tables in the cell.
	/// </summary>
	[SerializeField] private List<GameObject> _tables;

	/// <summary>
	/// The balloons in the cell.
	/// </summary>
	[SerializeField] private List<GameObject> _balloons;

	/// <summary>
	/// The npc groups in the cell.
	/// </summary>
	[SerializeField] private List<GameObject> _npcs;

	#endregion

	#region --------------------	Private Methods

	/// <summary>
	/// Testing
	/// </summary>
	private void Start ()
	{
		Generate_Cell ();
		Register_Cell_With_Map ();
	}

	/// <summary>
	/// Registers the cell instance with the map in order by position ( left to right, top to bottom ).
	/// </summary>
	private void Register_Cell_With_Map ()
	{
		bool _isAdded = false;
		for ( int c = 0; c < CELL_MAP.cellInstances.Count; c++ )
		{
			if ( cellPosition.y > CELL_MAP.cellInstances [ c ].cellPosition.y )
			{
				if ( cellPosition.x < CELL_MAP.cellInstances [ c ].cellPosition.x )
				{
					CELL_MAP.cellInstances.Insert ( c, this );
					_isAdded = true;
					break;
				}
			}
		}
		if ( !_isAdded )
		{
			CELL_MAP.cellInstances.Add ( this );
		}
	}

	#endregion

}