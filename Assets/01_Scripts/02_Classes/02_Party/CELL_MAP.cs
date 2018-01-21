using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
	public static void Enter_New_Cell ( Vector2 _offset, Transform _player )
	{
		if ( _offset != Vector2.zero )
		{
			foreach ( CELL c in cellInstances )
			{
				//	Move further cells to opposite side
				if ( Mathf.Abs ( c.cellPosition.x - _offset.x ) > 1 || Mathf.Abs ( c.cellPosition.y - _offset.y ) > 1 )
				{
					c.Translate ( new Vector3 ( _offset.x * 200.0f, 0, _offset.y * 200.0f ) );
					c.Generate_Cell ();
				}
				else
				{
					//	Rotate closer cells to center the player at 0, 0
					c.Translate ( new Vector3 ( _offset.x * -100.0f, 0, _offset.y * -100.0f ) );
				}
			}
			_player.position += ( new Vector3 ( _offset.x * -100.0f, 0, _offset.y * -100.0f ) );
		}
	}

	#endregion

}