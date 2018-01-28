using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ RequireComponent (  typeof ( CharacterController ), typeof ( Rigidbody ) ) ]
public class CUSTOM_THIRD_PERSON_CONTROLLER : MonoBehaviour 
{

	#region --------------------	Public Fields

	[ Space ]
	[ Header ( "Camera Settings" ) ]

	[ Tooltip ( "The point that will be the focus of the camera." ) ]
	/// <summary>
	/// The camera focus.
	/// </summary>
	public Transform cameraFocus = null;

	[ Tooltip ( "The maximum y angle that the camera will reach." ) ]
	[ Range ( -90.0f, 90.0f ) ]
	/// <summary>
	/// The camera Y max.
	/// </summary>
	public float cameraYMax = 50.0f;

	[ Tooltip ( "The minimum y angle that the camera will reach." ) ]
	[ Range ( -90.0f, 90.0f ) ]
	/// <summary>
	/// The camera Y minimum.
	/// </summary>
	public float cameraYMin = -20.0f;

	[ Tooltip ( "The sensitivity of the x movement of the camera." ) ]
	[ Range ( 1.0f, 10.0f ) ]
	/// <summary>
	/// The camera X sensitivity.
	/// </summary>
	public float cameraXSensitivity = 5.0f;

	[ Tooltip ( "The sensitivity of the y movement of the camera." ) ]
	[ Range ( 1.0f, 10.0f ) ]
	/// <summary>
	/// The camera Y sensitivity.
	/// </summary>
	public float cameraYSensitivity = 3.0f;

	[ Tooltip ( "The maximum camera distance from the character." ) ]
	[ Range ( 1.0f, 15.0f ) ]
	/// <summary>
	/// The maximum camera distance from the character.
	/// </summary>
	public float maxCameraDistance = 8.0f;

	[ Tooltip ( "The minimum camera distance from the character." ) ]
	[ Range ( 0.0f, 15.0f ) ]
	/// <summary>
	/// The minimum camera distance from the character.
	/// </summary>
	public float minCameraDistance = 2.0f;

	[ Tooltip ( "The camera's following speed." ) ]
	[ Range ( 3.0f, 20.0f ) ]
	/// <summary>
	/// The camera following speed.
	/// </summary>
	public float cameraSpeed = 8.0f;

	[ Tooltip ( "Determines if the camera's Y axis is inverted." ) ]
	/// <summary>
	/// Is the camera y axis inverted.
	/// </summary>
	public bool cameraInverted = false;

	[ Space ]
	[ Header ( "Movement Settings" ) ]

	[ Tooltip ( "The speed at which the player walks." ) ]
	[ Range ( 0.1f, 20.0f ) ]
	/// <summary>
	/// The walk speed.
	/// </summary>
	public float walkSpeed = 3.0f;

	[ Tooltip ( "Enables / Disables running." ) ]
	/// <summary>
	/// Is running enabled.
	/// </summary>
	public bool canRun = true;

	[ Tooltip ( "The speed at which the player runs." ) ]
	[ Range ( 0.1f, 20.0f ) ]
	/// <summary>
	/// The run speed.
	/// </summary>
	public float runSpeed = 5.0f;

	[ Tooltip ( "The key used for running." ) ]
	/// <summary>
	/// The run key.
	/// </summary>
	public KeyCode runKey = KeyCode.LeftShift;

	[ Tooltip ( "Enables / Disables jump." ) ]
	/// <summary>
	/// Is jumping enabled.
	/// </summary>
	public bool canJump = true;

	[ Tooltip ( "The speed at which the player jumps." ) ]
	[ Range ( 0.1f, 20.0f ) ]
	/// <summary>
	/// The jump speed.
	/// </summary>
	public float jumpSpeed = 3.0f;

	#endregion

	#region --------------------	Private Fields

	/// <summary>
	/// The main camera.
	/// </summary>
	private Camera _cam;

	/// <summary>
	/// The main camera collider tracker.
	/// </summary>
	private CUSTOM_THIRD_PERSON_CAMERA _camCollider;

	/// <summary>
	/// The camera rotation.
	/// </summary>
	private Vector2 _cameraRotation = Vector2.zero;

	/// <summary>
	/// The previous focus position.
	/// </summary>
	private Vector3 _previousFocusPosition = Vector3.zero;

	/// <summary>
	/// The current camera distance.
	/// </summary>
	private float _currentCameraDistance = 0f;

	/// <summary>
	/// The temporary camera distance limit.
	/// </summary>
	private float _tempMaxCameraDistance = 0f;

	/// <summary>
	/// The character controller.
	/// </summary>
	private CharacterController _char;

	/// <summary>
	/// The collision flags.
	/// </summary>
	private CollisionFlags _collisionFlags;

	/// <summary>
	/// The movement direction.
	/// </summary>
	private Vector3 _movementDirection = Vector3.zero;

	#endregion

	#region --------------------	Private Methods

	/// <summary>
	/// Start this instance.
	/// </summary>
	private void Start ()
	{
		//	Grab the main camera, its collision tracker, and subscribe to the collision stay event
		_cam = Camera.main;
		_camCollider = _cam.GetComponent <CUSTOM_THIRD_PERSON_CAMERA> ();
		_camCollider.ON_CAMERA_COLLISION_STAY += ReduceCameraDistance;

		//	Set the cursor configuration
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

		//	Define the camera focus & distance values
		cameraFocus = ( cameraFocus == null )? transform : cameraFocus;
		_previousFocusPosition = _cam.transform.forward;
		_currentCameraDistance = maxCameraDistance;
		_tempMaxCameraDistance = maxCameraDistance;

		//	Grab the character controller
		_char = GetComponent <CharacterController> ();
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	private void FixedUpdate ()
	{
		//	Collect the newest rotation input
		Vector2 _rotationInput = new Vector2 ( Input.GetAxis ( "Mouse X" ) * ( cameraXSensitivity * 10.0f ) * Time.deltaTime,
			( Input.GetAxis ( "Mouse Y" ) * ( cameraYSensitivity * 10.0f ) * ( ( cameraInverted ) ? -1.0f : 1.0f ) ) * Time.deltaTime );
		Vector2 _input = new Vector2 ( Input.GetAxisRaw ( "Horizontal" ), Input.GetAxisRaw ( "Vertical" ) );
		Vector3 _desiredMove = transform.forward * _input.y + transform.right * _input.x;

		//	Reset the temporary camera distance limit whenever there is mouse movement
		_tempMaxCameraDistance = ( _rotationInput == new Vector2 ( 0f, 0f ) && _input == new Vector2 ( 0f, 0f ) )? _tempMaxCameraDistance : maxCameraDistance;

		//	Adjust the camera rotation by the input from the mouse
		_cameraRotation += _rotationInput;

		//	Clamp the rotation within the supplied limits
		_cameraRotation.y = Mathf.Clamp ( _cameraRotation.y, cameraYMax * -1.0f, cameraYMin * -1.0f );

		//	Rotate the character
		transform.Rotate ( new Vector3 ( 0f, _rotationInput.x , 0f ) );

		//	Calculate desired movement and perform simple elevation checks / modifications to create an actual movement direction
		RaycastHit _hitInfo;
		Physics.SphereCast ( transform.position, _char.radius, Vector3.down, out _hitInfo, _char.height / 2.0f, Physics.AllLayers, QueryTriggerInteraction.Ignore );
		_desiredMove = Vector3.ProjectOnPlane ( _desiredMove, _hitInfo.normal ).normalized;
		_movementDirection.x = _desiredMove.x * ( ( canRun && Input.GetKey ( runKey ) ) ? runSpeed : walkSpeed );
		_movementDirection.z = _desiredMove.z * ( ( canRun && Input.GetKey ( runKey ) ) ? runSpeed : walkSpeed );

		//	Modify for jumping
		_movementDirection.y = ( _char.isGrounded && canJump && Input.GetKey ( KeyCode.Space ) )? jumpSpeed * 2.0f : 
			_movementDirection.y + ( Physics.gravity.y * Time.fixedDeltaTime * 5.0f ) ;

		//	Perform movement and collect collision information
		_collisionFlags = _char.Move ( _movementDirection * Time.fixedDeltaTime );
	}

	/// <summary>
	/// Raises the controller collider hit event.
	/// </summary>
	/// <param name="hit">Hit.</param>
	private void OnControllerColliderHit ( ControllerColliderHit hit )
	{
		Rigidbody body = hit.collider.attachedRigidbody;
		if ( _collisionFlags == CollisionFlags.Below )
		{
			return;
		}

		if ( body == null || body.isKinematic )
		{
			return;
		}
		body.AddForceAtPosition ( _char.velocity * -0.4f, hit.point, ForceMode.Impulse );
	}

	/// <summary>
	/// Called at the end of the frame
	/// </summary>
	private void LateUpdate ()
	{
		//	Update the camera distance to push back towards the desired distance
		_currentCameraDistance = ( _currentCameraDistance + ( Time.deltaTime * cameraSpeed * 0.4f ) < _tempMaxCameraDistance )? 
			_currentCameraDistance + (Time.deltaTime * cameraSpeed * 0.4f ) :  _tempMaxCameraDistance;

		//	Update the position of the camera
		_cam.transform.position = Vector3.Lerp ( _cam.transform.position, 
			( cameraFocus.position + Quaternion.Euler ( _cameraRotation.y, _cameraRotation.x, 0 ) * new Vector3 ( 0, 0, _currentCameraDistance ) ),
			Time.deltaTime * cameraSpeed );

		//	Rotate the camera to look at the character
		_previousFocusPosition = Vector3.Lerp ( _previousFocusPosition, cameraFocus.position, Time.deltaTime * cameraSpeed );
		_cam.transform.LookAt ( _previousFocusPosition );
	}

	/// <summary>
	/// Reduces the camera distance.
	/// </summary>
	private void ReduceCameraDistance ()
	{
		_currentCameraDistance = ( _currentCameraDistance - ( Time.fixedDeltaTime * cameraSpeed * ( ( canRun && Input.GetKey ( runKey ) ) ? 1.5f : 0.5f ) ) > minCameraDistance )?
			_currentCameraDistance - ( Time.fixedDeltaTime * cameraSpeed * ( ( canRun && Input.GetKey ( runKey ) ) ? 1.5f : 0.5f ) ) : minCameraDistance;
		_tempMaxCameraDistance = _currentCameraDistance;
	}

	#endregion

}
