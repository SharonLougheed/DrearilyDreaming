using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class INTERACTABLE_OBJECT : MonoBehaviour 
{

	#region --------------------	Public Properties

	/// <summary>
	/// Gets a value indicating whether this <see cref="INTERACTABLE_OBJECT"/> has interacted.
	/// </summary>
	/// <value><c>true</c> if has interacted; otherwise, <c>false</c>.</value>
	public bool hasInteracted { get { return _hasInteracted; } }

	#endregion

	#region --------------------	Public Fields

	[Tooltip ("The tag required by the user")]
	/// <summary>
	/// The user's required tag
	/// </summary>
	public string requiredTag = "Player";

	[Tooltip ("The key required to interact with the object")]
	/// <summary>
	/// The interaction key.
	/// </summary>
	public KeyCode interactionKey = KeyCode.E;

	[Tooltip ("Determines if the object may be interacted with multiple times")]
	/// <summary>
	/// Used to determine whether or not to disable further interactions after the first call.
	/// </summary>
	public bool isSingleInteraction = false;

	[Tooltip ("The interaction prompt object in the ui")]
	/// <summary>
	/// The interaction prompt.
	/// </summary>
	public GameObject interactionPrompt;

	#endregion

	#region --------------------	Public Methods

	/// <summary>
	/// Reset this instance.
	/// </summary>
	public void Reset ()
	{
		_hasInteracted = false;
	}

	#endregion

	#region --------------------	Protected Methods

	/// <summary>
	/// Interact with the object
	/// </summary>
	protected virtual IEnumerator Interact () 
	{
		return null;
	}

	#endregion

	#region --------------------	Private Fields

	/// <summary>
	/// Used to eval whether or not the object may be interacted with.
	/// </summary>
	private bool _isWithinRange = false;

	/// <summary>
	///	Used to prevent additional interactions if isSingleInteraction is true.
	/// </summary>
	private bool _hasInteracted = false;

	#endregion

	#region --------------------	Private Methods

	/// <summary>
	/// Raises the disable event.
	/// </summary>
	private void OnDisable ()
	{
        GetComponent<SphereCollider>().enabled = true;
        Reset ();
	}

	/// <summary>
	/// Raises the trigger enter event.
	/// </summary>
	/// <param name="other">Other.</param>
	private void OnTriggerEnter ( Collider other )
	{
		//_isWithinRange = ( other.CompareTag ( requiredTag ) ) ? true : _isWithinRange;
        //	If there is an interaction prompt, display it
        if (interactionPrompt != null && other.CompareTag(requiredTag))
        {
            interactionPrompt.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other) {
        //	If the user is within range and the object is not single interaction while having already been interacted with.
        //if (_isWithinRange && !(isSingleInteraction && _hasInteracted))
        //{
            
            //	If the interaction key is pressed, interact with the object
            if (other.CompareTag(requiredTag) && Input.GetKeyDown(interactionKey) && interactionPrompt != null)
            {
                Debug.Log("Interacted with " + name);
                _hasInteracted = true;
                //interactionPrompt.SetActive(!interactionPrompt.activeInHierarchy);
                StartCoroutine(Interact());
                //	If there is an interaction prompt, deactivate it
                //if (interactionPrompt != null)
                //{
                interactionPrompt.SetActive(false);
                //}
            }
        //}
    }

    /// <summary>
    /// Raises the trigger exit event.
    /// </summary>
    /// <param name="other">Other.</param>
    private void OnTriggerExit ( Collider other )
	{
		//_isWithinRange = ( other.CompareTag ( requiredTag ) ) ? false : _isWithinRange;
        //	If there is an interaction prompt, deactivate it
        if (interactionPrompt != null && other.CompareTag(requiredTag))
        {
            interactionPrompt.SetActive(false);
        }
    }

	/// <summary>
	/// Update this instance.
	/// </summary>
	//private void Update ()
	//{
	//	//	If the user is within range and the object is not single interaction while having already been interacted with.
	//	if ( _isWithinRange && !( isSingleInteraction && _hasInteracted ) )
	//	{
	//		//	If there is an interaction prompt, display it
	//		if ( interactionPrompt != null )
	//		{
	//			interactionPrompt.SetActive(true);
	//		}
	//		//	If the interaction key is pressed, interact with the object
	//		if ( Input.GetKeyDown ( interactionKey ) )
	//		{
	//			Debug.Log ( "Interacted with " + name );
	//			_hasInteracted = true;
 //               //interactionPrompt.SetActive(!interactionPrompt.activeInHierarchy);
	//			StartCoroutine ( Interact () );
	//		}
	//	}
	//}

	#endregion

}