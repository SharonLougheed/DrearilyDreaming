//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//[ RequireComponent ( typeof ( AudioSource ) ) ]
//[ DisallowMultipleComponent ]
//public class INTERACTABLE_BALLOON : INTERACTABLE_OBJECT 
//{
//
//	#region --------------------	Protected Methods
//
//	/// <summary>
//	/// Interact with the object
//	/// </summary>
//	protected override IEnumerator Interact ()
//	{
//		//	Play the balloon popping sound, then set the object to inactive
//		_audio.pitch += Random.Range ( -0.05f, 0.05f );
//		_audio.Play ();
//        gameObject.GetComponent<SphereCollider>().enabled = false;
//        
//		yield return new WaitWhile ( () => _audio.isPlaying );
//		gameObject.SetActive ( false );
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
