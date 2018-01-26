using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ RequireComponent ( typeof ( Rigidbody ), typeof ( CharacterController ) ) ]
public class CUSTOM_THIRD_PERSON_CONTROLLER : MonoBehaviour 
{

	#region --------------------	Public Fields

	[ Space ]
	[ Header ( "Camera Settings" ) ]

	[ Tooltip ( "The maximum y angle that the camera will reach." ) ]
	[ Range ( 0.0f, 90.0f ) ]
	/// <summary>
	/// The camera Y max.
	/// </summary>
	public float cameraYMax = 50.0f;

	[ Tooltip ( "The minimum y angle that the camera will reach." ) ]
	[ Range ( -90.0f, 0.0f ) ]
	/// <summary>
	/// The camera Y minimum.
	/// </summary>
	public float cameraYMin = 0.0f;

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

	[ Tooltip ( "The camera distance from the character." ) ]
	[ Range ( 1.0f, 15.0f ) ]
	/// <summary>
	/// The camera distance from the character.
	/// </summary>
	public float cameraDistance = 4.0f;

	[ Tooltip ( "The camera's following speed." ) ]
	[ Range ( 3.0f, 20.0f ) ]
	/// <summary>
	/// The camera following speed.
	/// </summary>
	public float cameraSpeed = 5.0f;

	[ Tooltip ( "Determines if the camera's Y axis is inverted." ) ]
	/// <summary>
	/// Is the camera y axis inverted.
	/// </summary>
	public bool cameraInverted = false;

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
	/// The desired camera distance.
	/// </summary>
	private float _desiredCameraDistance = 0;

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

		//	Store the desired camera distance
		_desiredCameraDistance = cameraDistance;
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	private void Update ()
	{
		//	Adjust the camera rotation by the input from the mouse
		_cameraRotation += new Vector2 ( Input.GetAxis ( "Mouse X" ) * ( cameraXSensitivity * 10.0f ) * Time.deltaTime,
			( Input.GetAxis ( "Mouse Y" ) * ( cameraYSensitivity * 10.0f ) * ( ( cameraInverted ) ? -1.0f : 1.0f ) ) * Time.deltaTime );

		//	Clamp the rotation within the supplied limits
		_cameraRotation.y = Mathf.Clamp ( _cameraRotation.y, cameraYMax * -1.0f, cameraYMin );
	}

	/// <summary>
	/// Called at the end of the frame
	/// </summary>
	private void LateUpdate ()
	{
		//	Update the camera distance to push back towards the desired distance
		cameraDistance += ( cameraDistance + ( Time.deltaTime * cameraSpeed ) < _desiredCameraDistance ) ? Time.deltaTime * cameraSpeed : ( _desiredCameraDistance - cameraDistance );

		//	Update the position of the camera
		_cam.transform.position = Vector3.Lerp ( _cam.transform.position, 
			( transform.position + Quaternion.Euler ( _cameraRotation.y, _cameraRotation.x, 0 ) * new Vector3 ( 0, 0, cameraDistance ) ),
			Time.deltaTime * cameraSpeed );

		//	Rotate the camera to look at the character
		_cam.transform.LookAt ( transform );
	}

	/// <summary>
	/// Reduces the camera distance.
	/// </summary>
	private void ReduceCameraDistance ()
	{
		cameraDistance -= Time.deltaTime * cameraSpeed;
	}

	#endregion

}
