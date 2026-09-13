using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private AudioClip musicClip;
    [SerializeField, Range(0f, 1f)] private float volume = 0.4f;

    private static BackgroundMusic instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.loop = true;
        audioSource.spatialBlend = 0f;
        audioSource.volume = volume;

        if (musicClip != null)
            audioSource.clip = musicClip;

        if (audioSource.clip == null)
        {
            Debug.LogError("Background Music requires an AudioClip assigned to the script or Audio Source.", this);
            return;
        }

        audioSource.Play();
    }
}
