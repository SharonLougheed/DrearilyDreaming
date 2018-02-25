using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class INNER_DIALOG : MonoBehaviour
{

	#region --------------------	Private Fields

	[ SerializeField ] private Image _blackScreen;
	[ SerializeField ] private CanvasGroup _thoughtBubble;
	[ SerializeField ] private Text _innerThoughts;
	[ SerializeField ] private AudioSource _audio;
	[ SerializeField ] private AudioClip _fallingSound;
	[ SerializeField ] private UnityStandardAssets.Characters.FirstPerson.FirstPersonController _fps;
	[ SerializeField ] private AudioSource _stereo;
	[ SerializeField ] private AudioSource _crowd;
	private List <string> _thoughts = new List<string> {
		"I wonder where that music is coming from.",
		"Is Joe nearby?",
		"I wish I could find someone to talk to.",
		"I wonder if there's someone I know here.",
		"I bet Joe is jamming to this music."
	};

	#endregion

	#region --------------------	Private Methods

	private void Start ()
	{
		_blackScreen = GameObject.Find ( "blackScreen" ).GetComponent <Image> ();
		StartCoroutine ( First_Thought () );
	}

	private void Update ()
	{
		_blackScreen.color = ( _blackScreen.color.a > 0 && _fps.enabled )? new Color ( 0, 0, 0, ( _blackScreen.color.a - Time.deltaTime ) ) : _blackScreen.color;
		if ( PlayerNotoriety.GetPlayerNotoriety () <= -5f && _fps.enabled )
		{
			_fps.enabled = false;
			StopAllCoroutines ();
			StartCoroutine ( Wake_Up () );
		}
	}

	private IEnumerator First_Thought ()
	{
		yield return new WaitForSeconds ( 5f );
		_innerThoughts.text = "I wonder if Joe is going to be at this party.";
		while ( _thoughtBubble.alpha < 1 )
		{
			_thoughtBubble.alpha += Time.deltaTime;
			yield return new WaitForSeconds ( Time.deltaTime );
		}
		yield return new WaitForSeconds ( 5f );
		while ( _thoughtBubble.alpha > 0 )
		{
			_thoughtBubble.alpha -= Time.deltaTime;
			yield return new WaitForSeconds ( Time.deltaTime );
		}
		StartCoroutine ( Think () );
	}

	private IEnumerator Think()
	{
		yield return new WaitForSeconds ( 60f );
		_innerThoughts.text = _thoughts [ Random.Range ( 0, _thoughts.Count ) ];
		while ( _thoughtBubble.alpha < 1 )
		{
			_thoughtBubble.alpha += Time.deltaTime;
			yield return new WaitForSeconds ( Time.deltaTime );
		}
		yield return new WaitForSeconds ( 5f );
		while ( _thoughtBubble.alpha > 0 )
		{
			_thoughtBubble.alpha -= Time.deltaTime;
			yield return new WaitForSeconds ( Time.deltaTime );
		}
		StartCoroutine ( Think () );
	}

	private IEnumerator Wake_Up()
	{
		_innerThoughts.text = "Something's wrong!";
		while ( _thoughtBubble.alpha < 1f )
		{
			_blackScreen.color = new Color ( 0, 0, 0, _blackScreen.color.a + Time.deltaTime ); 
			_thoughtBubble.alpha += Time.deltaTime;
			yield return new WaitForSeconds ( Time.deltaTime );
		}
		yield return new WaitForSeconds ( 2f );
		while ( _thoughtBubble.alpha > 0f )
		{
			_stereo.volume -= Time.deltaTime * 3.0f;
			_crowd.volume -= Time.deltaTime * 3.0f;
			_thoughtBubble.alpha -= Time.deltaTime;
			yield return new WaitForSeconds ( Time.deltaTime );
		}
		PlayerNotoriety.ResetPlayerNoteriety ();
		_audio.PlayOneShot ( _fallingSound, 4.0f );
		SceneManager.LoadScene ( 1 );
	}

	#endregion

}