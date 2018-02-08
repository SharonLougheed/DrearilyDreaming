using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ RequireComponent ( typeof ( SphereCollider ), typeof ( AudioSource ), typeof ( Animator ) ) ]
[ DisallowMultipleComponent ]
public class INTERACTABLE : MonoBehaviour 
{

	#region --------------------	Public Enumerations

	/// <summary>
	/// The interactable types
	/// </summary>
	public enum TYPE { NONE, BED, PARTY_NPC, PARTY_SPECIAL, PARTY_BALLOON, PARTY_STEREO, PARTY_PUNCH, PARTY_FOOD };

	#endregion

	#region --------------------	Public Events

	/// <summary>
	/// Interaction Events:
	/// On Interaction Begin is called whenever the object has had interaction initiated.
	/// On Interaction End is called whenever the object has had interaction completed.
	/// </summary>
	public delegate void INTERACTABLE_EVENT ( TYPE _interactionType );
	public event INTERACTABLE_EVENT On_Interaction_Begin;
	public event INTERACTABLE_EVENT On_Interaction_End;

	#endregion

	#region --------------------	Public Fields

	[ Space ]
	[ Header ( "Interactable Configurations" ) ]

	[ Tooltip ( "The type of interaction the object will have" ) ]
	/// <summary>
	/// The type of the interaction.
	/// </summary>
	public TYPE interactionType = TYPE.NONE;

	[ Tooltip ( "The list of interactable tags" ) ]
	/// <summary>
	/// The interactable tags.
	/// </summary>
	public List <string> interactableTags;

	[ Tooltip ( "The key required to interact with the object" ) ]
	/// <summary>
	/// The interaction key.
	/// </summary>
	public KeyCode interactionKey = KeyCode.E;

	[ Tooltip ( "Determines if the object may be interacted with multiple times" ) ]
	/// <summary>
	/// Used to determine whether or not to disable further interactions after the first call.
	/// </summary>
	public bool isSingleInteraction = false;

	[ Tooltip ( "The text displayed as a prompt for interaction by the player" ) ]
	/// <summary>
	/// The interaction prompt.
	/// </summary>
	public string interactionPrompt = "Interact with object";

	[ Tooltip ( "Determines if the object's interaction prompt is hooked into the default prompt tagged as 'UI_Interaction_Prompt'" ) ]
	/// <summary>
	/// Does the interaction hook into the default prompt.
	/// </summary>
	public bool usesDefaultPromptObject = true;

	[ Tooltip ( "The ui hook to use if 'usesDefaultPrompt' is set to false" ) ]
	/// <summary>
	/// The custom prompt used if default hook is set to false.
	/// </summary>
	public Text customPrompt = null;

	#endregion

	#region --------------------	Public Methods

	/// <summary>
	/// Called whenever an NPC wishes to interact with an object.
	/// </summary>
	public void NPC_Interaction ()
	{
		_npcInteractionAttempt = true;
	}

	#endregion

	#region --------------------	Private Fields

	/// <summary>
	/// The mesh renderer.
	/// </summary>
	private MeshRenderer _meshRenderer = null;

	/// <summary>
	/// The audio source.
	/// </summary>
	private AudioSource _audioSource = null;

	/// <summary>
	/// The default interaction prompt.
	/// </summary>
	private Text _defaultInteractionPrompt = null;

	/// <summary>
	/// The cell entity.
	/// </summary>
	private CELL_ENTITY _cellEntity = null;

	/// <summary>
	/// Is the object currently being interacted with.
	/// </summary>
	private bool _isBeingInteractedWith = false;

	/// <summary>
	/// Has the object been interacted with.
	/// </summary>
	private bool _hasBeenInteractedWith = false;

	/// <summary>
	/// Has an npc tried to interact with the object.
	/// </summary>
	private bool _npcInteractionAttempt = false;

	/// <summary>
	/// The various interactions.
	/// </summary>
	private Dictionary <TYPE, string> _interaction = new Dictionary < TYPE, string> {
		{ TYPE.NONE, null },
		{ TYPE.BED, "Bed_Interaction" },
		{ TYPE.PARTY_NPC, "Party_NPC_Interaction" },
		{ TYPE.PARTY_SPECIAL, "Party_Special_Interaction" },
		{ TYPE.PARTY_BALLOON, "Balloon_Interaction" },
		{ TYPE.PARTY_STEREO, "Stereo_Interaction" },
		{ TYPE.PARTY_PUNCH, "Punch_Interaction" },
		{ TYPE.PARTY_FOOD, "Food_Interaction" }
	};

	#endregion

	#region --------------------	Private Methods

	/// <summary>
	/// Start this instance.
	/// </summary>
	private void Start ()
	{
		_meshRenderer = GetComponent <MeshRenderer> ();
		_audioSource = GetComponent <AudioSource> ();
		_cellEntity = GetComponent <CELL_ENTITY> ();
		if ( _cellEntity != null )
		{
			_cellEntity.On_Cell_Entity_Generate += delegate {
				_meshRenderer.enabled = true;
				_hasBeenInteractedWith = false;
			};
		}
		_defaultInteractionPrompt = GameObject.FindGameObjectWithTag ( "UI_Interaction_Prompt" ).GetComponent <Text> ();
	}

	/// <summary>
	/// Raises the trigger stay event.
	/// </summary>
	/// <param name="_c">C.</param>
	private void OnTriggerStay ( Collider _c )
	{
		//	If the objects are allowed to interact with one another
		if ( interactableTags.Contains ( _c.tag ) )
		{
			//	If the object is rendered by the camera
			if ( _meshRenderer.isVisible )
			{
				//	If the object raising the trigger is not an npc, enable player interaction
				if ( !_c.tag.Contains ( "NPC" ) )
				{
					//	Display the prompt
					if ( usesDefaultPromptObject )
					{
						//	Enable the default prompt if it is available
						if ( _defaultInteractionPrompt != null )
						{
							//	Add the prompt text to the prompt object
							if ( _defaultInteractionPrompt.text.Length > 0 )
							{
								bool _isPromptAdded = new List <string> ( _defaultInteractionPrompt.text.Split ( new string[] { "\n" }, System.StringSplitOptions.RemoveEmptyEntries ) ).Contains ( interactionPrompt );
								_defaultInteractionPrompt.text += ( !_isPromptAdded ) ? interactionPrompt + "\n" : "";
							}
							else
							{
								_defaultInteractionPrompt.text += interactionPrompt + "\n";
							}

							//	Show the prompt object
							_defaultInteractionPrompt.gameObject.SetActive ( true );
						}
					}
					else
					{
						//	Enable the custom prompt if it is supplied
						if ( customPrompt != null )
						{
							//	Add the prompt text to the prompt object
							if ( customPrompt.text.Length > 0 )
							{
								bool _isPromptAdded = new List <string> ( customPrompt.text.Split ( new string[] { "\n" }, System.StringSplitOptions.RemoveEmptyEntries ) ).Contains ( interactionPrompt );
								customPrompt.text += ( !_isPromptAdded ) ? interactionPrompt + "\n" : "";
							}
							else
							{
								customPrompt.text += interactionPrompt + "\n";
							}

							//	Show the prompt object
							customPrompt.gameObject.SetActive ( true );
						}
					}

					//	Check to see if the input is pressed & the object is not currently being interacted with
					if ( Input.GetKeyDown ( interactionKey ) && !_isBeingInteractedWith )
					{
						//	If the object can be interacted with
						bool _i = false;
						_i = ( isSingleInteraction ) ? !_hasBeenInteractedWith : true;
						if ( _i )
						{
							//	Interaction Startup
							if ( On_Interaction_Begin != null )
							{
								On_Interaction_Begin ( interactionType );
							}
							_isBeingInteractedWith = true;

							//	Perform the interaction
							StartCoroutine ( _interaction [ interactionType ] );

							//	Interaction Completion
							_hasBeenInteractedWith = true;
							if ( On_Interaction_End != null )
							{
								On_Interaction_End ( interactionType );
							} 
						}
					}
				}
				else
				{
					//	Enable NPC interaction
					//	Check to see if the object is not currently being interacted with
					if ( !_isBeingInteractedWith && _npcInteractionAttempt)
					{
						//	If the object can be interacted with
						bool _i = false;
						_i = ( isSingleInteraction ) ? !_hasBeenInteractedWith : true;
						if ( _i )
						{
							//	Interaction Startup
							if ( On_Interaction_Begin != null )
							{
								On_Interaction_Begin ( interactionType );
							}
							_isBeingInteractedWith = true;

							//	Perform the interaction
							StartCoroutine ( _interaction [ interactionType ] );

							//	Interaction Completion
							_hasBeenInteractedWith = true;
							_npcInteractionAttempt = false;
							if ( On_Interaction_End != null )
							{
								On_Interaction_End ( interactionType );
							} 
						}
					}
				}
			}
		}
	}

	/// <summary>
	/// Raises the trigger exit event.
	/// </summary>
	/// <param name="_c">C.</param>
	private void OnTriggerExit ( Collider _c = null )
	{
		//	If the two objects are allowed to interact with one another.
		if ( _c == null || interactableTags.Contains ( _c.tag ) )
		{
			//	Hide the prompt
			if ( usesDefaultPromptObject )
			{
				//	Disable the default prompt if it is available
				if ( _defaultInteractionPrompt != null )
				{
					//	Remove the interaction prompt from the prompt text
					List <string> _modifiedPrompt = new List <string> ( _defaultInteractionPrompt.text.Split ( new string[] { "\n" }, 
						                                System.StringSplitOptions.RemoveEmptyEntries ) );
					_modifiedPrompt.Remove ( interactionPrompt );
					_defaultInteractionPrompt.text = "";
					_modifiedPrompt.ForEach ( p => _defaultInteractionPrompt.text += p + "\n" );

					//	Hide the prompt object
					_defaultInteractionPrompt.gameObject.SetActive ( false );
				}
			}
			else
			{
				//	Disable the custom prompt if it is supplied
				if ( customPrompt != null )
				{
					//	Remove the interaction prompt from the prompt text
					List <string> _modifiedPrompt = new List <string> ( customPrompt.text.Split ( new string[] { "\n" }, 
						                                System.StringSplitOptions.RemoveEmptyEntries ) );
					_modifiedPrompt.Remove ( interactionPrompt );
					customPrompt.text = "";
					_modifiedPrompt.ForEach ( p => customPrompt.text += p + "\n" );

					//	Hide the prompt object
					customPrompt.gameObject.SetActive ( false );
				}
			}
		}
	}
		
	/// <summary>
	/// Interaction with the bed.
	/// </summary>
	/// <returns>The interaction.</returns>
	private IEnumerator Bed_Interaction ()
	{
		//	Perform the interaction

		//	**************************
		//	Animate!
		//	**************************

		Debug.Log ( "Go to bed" );
		yield return null;
		_isBeingInteractedWith = false;
	}

	/// <summary>
	/// Interaction with an NPC at the party.
	/// </summary>
	/// <returns>The interaction.</returns>
	private IEnumerator Party_NPC_Interaction ()
	{
		//	Perform the interaction


		//	**************************
		//	Animate!
		//	**************************

		Debug.Log ( "Interaction with an npc" );
		yield return null;
		_isBeingInteractedWith = false;
	}

	/// <summary>
	/// Interaction with the special NPC at the party.
	/// </summary>
	/// <returns>The interaction.</returns>
	private IEnumerator Party_Special_Interaction ()
	{
		//	Perform the interaction
		UnityEngine.SceneManagement.SceneManager.LoadScene ( 1 );

		//	**************************
		//	Animate!
		//	**************************

		Debug.Log ( "Interaction with the special NPC" );
		yield return null;
		_isBeingInteractedWith = false;
	}

	/// <summary>
	/// Interaction with a balloon.
	/// </summary>
	/// <returns>The interaction.</returns>
	private IEnumerator Balloon_Interaction ()
	{
		//	Wait a random time to stagger clustered baloons
		yield return new WaitForSeconds ( Random.Range ( 0.01f, 0.25f ) );

		//	Play popping audio
		_audioSource.pitch += Random.Range ( -0.05f, 0.05f );
		_audioSource.Play ();

		//	Hide the balloon
		_meshRenderer.enabled = false;

		//	Disable further interaction
		OnTriggerExit ();

		//	Wait for audio clip to complete
		yield return new WaitWhile ( () => _audioSource.isPlaying );

		//	Set being interacted with to false
		_isBeingInteractedWith = false;

		//	De-activate the game object
		gameObject.SetActive ( false );

        //Modify notoriety field
        PlayerNotoriety.DecreasePlayerNotoriety();

		//	Flush the point of interest and retarget all audience NPCs
		_cellEntity.Flush_Point_Of_Interest ();
	}

	/// <summary>
	/// Interaction with a stereo.
	/// </summary>
	/// <returns>The interaction.</returns>
	private IEnumerator Stereo_Interaction ()
	{
		//	Perform the interaction
		CELL.isMusicPlaying = !CELL.isMusicPlaying;


		//	**************************
		//	Animate!
		//	**************************
		//Modify notoriety field
		if ( CELL.isMusicPlaying )
		{
			PlayerNotoriety.IncreasePlayerNotoriety ();
		} 
		else 
		{
			PlayerNotoriety.DecreasePlayerNotoriety ();
		}
        yield return new WaitForSeconds ( 3 );
		_isBeingInteractedWith = false;
	}

	/// <summary>
	/// Interaction with the punch.
	/// </summary>
	/// <returns>The interaction.</returns>
	private IEnumerator Punch_Interaction ()
	{
		//	Perform the interaction

		//	**************************
		//	Animate!
		//	**************************

		Debug.Log ( "Drink punch" );
        //Modify notoriety field
        PlayerNotoriety.IncreasePlayerNotoriety();
        yield return null;
		_isBeingInteractedWith = false;
	}

	/// <summary>
	/// Interaction with the food.
	/// </summary>
	/// <returns>The interaction.</returns>
	private IEnumerator Food_Interaction ()
	{
		//	Perform the interaction

		//	**************************
		//	Animate!
		//	**************************

		Debug.Log ( "Eat food" );
        //Modify notoriety field
        PlayerNotoriety.DecreasePlayerNotoriety();
        yield return null;
		_isBeingInteractedWith = false;
	}
	#endregion
}