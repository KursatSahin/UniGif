using UnityEngine;
using System.Collections;
using PowerTools;

/// Example of character with run/idle animations using the SpriteAnim component
public class Runner : MonoBehaviour {

	// The speed of the character, set in the inspector
	public float m_speed = 0;
	// Idle and run animations, drag your animations into these fields in the inspector
	public AnimationClip m_idle = null;
	public AnimationClip m_run = null;

	SpriteAnim m_anim = null;

	// Use this for initialization
	void Start () {

		// Store the sprite animation component so we don't have to get it again every frame
		m_anim = GetComponent<SpriteAnim>();

		// Start playing the idle animation
		m_anim.Play(m_idle);	
	}
	
	// Update is called once per frame
	void Update () {

		float direction = 0;
		if ( Input.GetKey(KeyCode.LeftArrow) )
			direction = -1;

		if ( Input.GetKey(KeyCode.RightArrow) )
			direction = 1;

		if ( direction == 0 )
		{
			if ( m_anim.GetCurrentAnimation() != m_idle )
				m_anim.Play(m_idle);
		}
		else
		{
			if ( m_anim.GetCurrentAnimation() != m_run )
				m_anim.Play(m_run);

			transform.Translate(new Vector3(direction * m_speed * Time.deltaTime, 0, 0 ) );
			if ( transform.localScale.x != direction )
				transform.localScale = new Vector3( direction, 1, 1 );			
		}
	
	}
}