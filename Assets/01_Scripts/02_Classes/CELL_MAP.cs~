using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CELL_MAP
{

	#region --------------------	Public Fields

	/// <summary>
	/// The map cells in the scene.
	/// </summary>
	public static List<CELL> cellInstances = new List<CELL> ();

	#endregion

	#region --------------------	Public Methods

	/// <summary>
	/// Called when the player enters a new cell.  Moves the unused cells to the opposite side of the grid and regenerates them.
	/// </summary>
	/// <param name="cell_position">Cell position.</param>
	public static void Enter_New_Cell ( Vector2 cell_position )
	{
		foreach ( CELL c in cellInstances )
		{
			if ( Mathf.Abs ( c.cellPosition.x - cell_position.x ) > 1 )
			{
				c.transform.position += new Vector3 ( ( c.cellPosition.x - cell_position.x > 0 ) ? -300.0f : 300.0f , 0, 0 );
				c.Generate_Cell ();
			}
			if ( Mathf.Abs ( c.cellPosition.y - cell_position.y ) > 1 )
			{
				c.transform.position += new Vector3 ( 0, 0, ( c.cellPosition.y - cell_position.y > 0 ) ? -300.0f : 300.0f );
				c.Generate_Cell ();
			}
		}
	}

	#endregion

}