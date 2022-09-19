using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAudioController : MonoBehaviour
{
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private AudioClip[] audioClips;
	[Range(0f, 1f)]
	[SerializeField] private float volume;

	private CharacterMover mover;
	private float randomVolumeOffset = 0.2f;
	private float speedThreshold = 0.05f;
	private float footstepDistance = 1f;
	private float currentFootstepDistance = 0f;

	// Start is called before the first frame update
	private void Awake()
    {
		mover = GetComponent<CharacterMover>();
    }

    // Update is called once per frame
    private void Update()
    {
		if (!mover) return;

		FootStepUpdate(mover.velocity);
	}

	void FootStepUpdate(float velocity)
	{
		currentFootstepDistance += Time.deltaTime * velocity;

		//Play foot step audio clip if a certain distance has been traveled;
		if (currentFootstepDistance > footstepDistance)
		{
			//Only play footstep sound if mover is grounded and movement speed is above the threshold;
			if (velocity > speedThreshold)
				PlayFootstepSound();
			currentFootstepDistance = 0f;
		}
	}

	void PlayFootstepSound()
	{
		int randomIndex = Random.Range(0, audioClips.Length);
		audioSource.PlayOneShot(audioClips[randomIndex], volume + volume * Random.Range(-randomVolumeOffset, randomVolumeOffset));
	}
}
