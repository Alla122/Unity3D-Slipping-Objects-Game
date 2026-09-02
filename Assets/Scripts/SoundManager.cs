using UnityEngine;

/// <summary>
/// Sound effect manager for audio feedback
/// </summary>
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] private AudioClip collisionSound;
    [SerializeField] private AudioClip goalSound;
    [SerializeField] private AudioClip buttonClickSound;
    [SerializeField] private float volume = 0.8f;

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlayCollisionSound(Vector3 position)
    {
        if (collisionSound != null)
            PlaySound(collisionSound, position);
    }

    public void PlayGoalSound(Vector3 position)
    {
        if (goalSound != null)
            PlaySound(goalSound, position);
    }

    public void PlayButtonClickSound()
    {
        if (buttonClickSound != null)
            audioSource.PlayOneShot(buttonClickSound, volume);
    }

    private void PlaySound(AudioClip clip, Vector3 position)
    {
        AudioSource.PlayClipAtPoint(clip, position, volume);
    }
}
