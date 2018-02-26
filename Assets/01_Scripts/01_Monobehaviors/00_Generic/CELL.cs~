using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[ DisallowMultipleComponent ]
public class CELL : MonoBehaviour 
{

	#region --------------------	Public Events

	/// <summary>
	/// Cell events:
	/// On Cell Generate is called whenever the cell is told to generate.
	/// </summary>
	public delegate void CELL_EVENT ();
	public event CELL_EVENT On_Cell_Generate;

	/// <summary>
	/// Cell Translation Events
	/// On Cell Translate is called whenever the cell is moved.
	/// </summary>
	public delegate void CELL_TRANSLATION ( Vector3 _direction );
	public event CELL_TRANSLATION On_Cell_Translate;

	#endregion

	#region --------------------	Public Properties

	/// <summary>
	/// Gets the rounded cell position.
	/// </summary>
	/// <value>The position.</value>
	public Vector3 position { 
		get {
			return new Vector3 ( Mathf.Round ( transform.position.x / 100.0f ),
				Mathf.Round ( transform.position.y / 100.0f ),
				Mathf.Round ( transform.position.z / 100.0f ) );
		} 
	}

	/// <summary>
	/// Gets the points of interest.
	/// </summary>
	/// <value>The points of interest.</value>
	public List <CELL_ENTITY> pointsOfInterest { get { return _pointsOfInterest; } }

	/// <summary>
	/// Gets a random point of interest.
	/// </summary>
	/// <value>The random point of interest.</value>
	public CELL_ENTITY randomPointOfInterest { get { return _pointsOfInterest [ Random.Range ( 0, _pointsOfInterest.Count ) ]; } }

	/// <summary>
	/// Gets a value indicating whether this <see cref="CELL"/> has completed translation.
	/// </summary>
	/// <value><c>true</c> if has completed translation; otherwise, <c>false</c>.</value>
	public bool hasCompletedTranslation { get { return _hasCompletedTranslation; } }

	/// <summary>
	/// Gets a value indicating whether this <see cref="CELL"/> has special.
	/// </summary>
	/// <value><c>true</c> if has special; otherwise, <c>false</c>.</value>
	public bool hasSpecial { get { return _hasSpecial; } }

	#endregion

	#region --------------------	Public Fields

	/// <summary>
	/// All cells.
	/// </summary>
	public static List <CELL> allCells = new List<CELL> ();

	/// <summary>
	/// The exit door.
	/// </summary>
	public GameObject exitDoor = null;

	#endregion

	#region --------------------	Public Methods



	#endregion

	#region --------------------	Private Properties

	/// <summary>
	/// Gets the player postion.
	/// </summary>
	/// <value>The player postion.</value>
	private Vector3 playerPosition
	{
		get {
			return new Vector3 ( Mathf.Round ( _player.position.x / 100.0f ),
				Mathf.Round ( _player.position.y / 100.0f ),
				Mathf.Round ( _player.position.z / 100.0f ) );
		} 
	}

	#endregion

	#region --------------------	Private Fields

	/// <summary>
	/// The player.
	/// </summary>
	private static Transform _player;

	/// <summary>
	/// The number of cell updates.
	/// </summary>
	private static int _cellUpdates = 0;

	/// <summary>
	/// Is this the first update loop.
	/// </summary>
	private bool _firstUpdate = true;

	/// <summary>
	/// Has the cell started translation.
	/// </summary>
	private bool _hasStartedTranslation = false;

	/// <summary>
	/// Has the cell completed translation.
	/// </summary>
	private bool _hasCompletedTranslation = false;

	/// <summary>
	/// The points of interest.
	/// </summary>
	private List <CELL_ENTITY> _pointsOfInterest;

	/// <summary>
	/// Does the cell have the special npc.
	/// </summary>
	private bool _hasSpecial = false;

	#endregion

	#region --------------------	Private Methods

	/// <summary>
	/// Awake this instance.
	/// </summary>
	private void Awake ()
	{
		allCells.Add ( this );
	}

	/// <summary>
	/// Start this instance.
	/// </summary>
	private void Start ()
	{
		_player = ( _player == null )? GameObject.FindGameObjectWithTag ( "Player" ).transform : _player;
		_pointsOfInterest = new List<CELL_ENTITY> ();
	}

	/// <summary>
	/// Called at the end of the execution order.
	/// </summary>
	private void Update ()
	{
		//	On the first update, generate each cell
		if ( _firstUpdate )
		{
			Generate ();
			_firstUpdate = false;
		}

		//	If the difference between the cell distance and player position is large enough, translate and regenerate the cell
		if ( !_hasStartedTranslation )
		{
			if ( playerPosition != Vector3.zero )
			{
				_hasCompletedTranslation = false;
				StartCoroutine ( Translate () );
				_cellUpdates++;
				_hasStartedTranslation = true;
				if ( _cellUpdates == 9 )
				{
					_player.parent.position -= playerPosition * 100.0f;
					_cellUpdates = 0;
				}
			}
		}
		else
		{
			if ( _cellUpdates == 0 )
			{
				_hasStartedTranslation = false;
			}
		}

		if ( PlayerNotoriety.GetPlayerNotoriety () <= -3.0f )
		{
			exitDoor.SetActive ( true );
		}
		else
		{
			exitDoor.SetActive ( false );
		}
	}

	/// <summary>
	/// Raises the trigger enter event.
	/// </summary>
	/// <param name="_c">C.</param>
	private void OnTriggerEnter ( Collider _c )
	{
		//	Become the parent of the special npc
		if ( _c.name.Equals ( "JOE" ) )
		{
			_c.transform.parent = transform;
			_c.GetComponent <NPC> ().Change_Parent ();
		}
	}

	/// <summary>
	/// Translate the cell in the specified _direction.
	/// </summary>
	/// <param name="_direction">Direction.</param>
	private IEnumerator Translate ()
	{
		//	Get player direction
		Vector3 _direction = ( playerPosition - position );

		//	Calculate a modified direction
		Vector3 _modifiedDirection = new Vector3 ( ( Mathf.Abs ( _direction.x ) > 1 )? ( ( _direction.x > 0 )? 200.0f : -200.0f ) : ( playerPosition.x * -100.0f ), 0,
			( Mathf.Abs ( _direction.z ) > 1 )? ( ( _direction.z > 0 )? 200.0f : -200.0f ) : ( playerPosition.z * -100.0f ) );

		//	Notify subscribers of translation
		if ( On_Cell_Translate != null )
		{
			On_Cell_Translate ( _modifiedDirection );
		}
			
		//	Move the cell & its children to a new position based on the direction.
		transform.position += _modifiedDirection;

		//	Regenerate the cell with a newly randomized configuration
		if ( _direction.magnitude >= 2 )
		{
			Generate ();
		}

		//	Show translation complete
		_hasCompletedTranslation = true;
		if ( _cellUpdates == 8 )
		{
			CELL_STEREO.instance.Translate ( _modifiedDirection );
		}

		//	Return null
		yield return null;
	}

	/// <summary>
	/// Generate this instance.
	/// </summary>
	private void Generate ()
	{
		if ( On_Cell_Generate != null )
		{
			On_Cell_Generate ();
		}
	}

	#endregion

}