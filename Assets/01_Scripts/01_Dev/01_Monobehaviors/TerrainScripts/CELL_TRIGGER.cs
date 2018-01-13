using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CELL_TRIGGER : MonoBehaviour
{

	#region --------------------	Private Fields

	/// <summary>
	/// The container for the cell script attached to the trigger's parent.
	/// </summary>
	private CELL _my_cell;

	#endregion

	#region --------------------	Private Methods

	/// <summary>
	/// Grab the cell script on the parent.
	/// </summary>
	private void Start ()
	{
		_my_cell = GetComponentInParent <CELL> ();
	}

	/// <summary>
	/// Calls the enter new cell method which restructures the active cell grid.
	/// </summary>
	/// <param name="c">C.</param>
	private void OnTriggerEnter ( Collider c )
	{
		CELL_MAP.Enter_New_Cell ( _my_cell.cellPosition );
	}

	#endregion

}