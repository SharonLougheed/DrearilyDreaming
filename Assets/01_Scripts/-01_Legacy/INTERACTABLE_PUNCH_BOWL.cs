//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//[ RequireComponent ( typeof ( AudioSource ) ) ]
//[ DisallowMultipleComponent ]
//public class INTERACTABLE_PUNCH_BOWL : INTERACTABLE_OBJECT 
//{
//
//	#region --------------------	Protected Methods
//
//	/// <summary>
//	/// Interact with the object
//	/// </summary>
//	protected override IEnumerator Interact ()
//	{
//		//	Play the punch bowl sound???, then do something???
//		_audio.pitch += Random.Range ( -0.05f, 0.05f );
//		_audio.Play ();
//		yield return new WaitWhile ( () => _audio.isPlaying );
//		//	Do something
//	}
//
//	#endregion
//
//	#region --------------------	Private Fields
//
//	/// <summary>
//	/// The audio source component.
//	/// </summary>
//	private AudioSource _audio;
//
//	#endregion
//
//	#region --------------------	Private Methods
//
//	/// <summary>
//	/// Awake this instance.
//	/// </summary>
//	private void Awake ()
//	{
//		_audio = GetComponent <AudioSource> ();
//	}
//
//	#endregion
//
//}
