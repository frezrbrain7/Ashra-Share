using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float WalkingSpeed = 5f;
    public float RunningSpeed = 9f;
    [Header("Footsteps")]
    public AudioClip FootstepClip;
    [Range(0f, 1f)] public float FootstepVolume = 0.35f;

    private float CurrentSpeed;
    private Rigidbody2D rb;
    private Vector2 moveDir;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    private AudioClip footstepClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.playOnAwake = false;
        audioSource.loop = true;
        audioSource.spatialBlend = 0f;
        footstepClip = FootstepClip != null ? FootstepClip : CreateFootstepClip();
        audioSource.clip = footstepClip;
        audioSource.volume = FootstepVolume;
    }

    // Update is called once per frame
    void Update()
    {
        moveDir = Vector2.zero;
        CurrentSpeed = WalkingSpeed;

        if (Keyboard.current.aKey.isPressed) moveDir += Vector2.left;
        if (Keyboard.current.dKey.isPressed) moveDir += Vector2.right;
        if (Keyboard.current.wKey.isPressed) moveDir += Vector2.up;
        if (Keyboard.current.sKey.isPressed) moveDir += Vector2.down;

        if (Keyboard.current.leftShiftKey.isPressed)
            CurrentSpeed = RunningSpeed;
        else
            CurrentSpeed = WalkingSpeed;

        moveDir = moveDir.normalized;

        if (moveDir.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveDir.x > 0)
        {
            spriteRenderer.flipX = false;
        }

        bool isMoving = moveDir != Vector2.zero;
        animator.SetBool("isMoving", isMoving);
        UpdateFootsteps(isMoving);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDir * CurrentSpeed * Time.fixedDeltaTime);
    }

    private void UpdateFootsteps(bool isMoving)
    {
        if (!isMoving)
        {
            if (audioSource.isPlaying)
                audioSource.Stop();
            return;
        }

        if (!audioSource.isPlaying)
            audioSource.Play();
    }

    private AudioClip CreateFootstepClip()
    {
        const int sampleRate = 44100;
        const float duration = 0.12f;
        int sampleCount = Mathf.RoundToInt(sampleRate * duration);
        float[] samples = new float[sampleCount];
        uint noiseState = 0x12345678;

        for (int i = 0; i < sampleCount; i++)
        {
            float time = i / (float)sampleRate;
            float envelope = 1f - time / duration;
            float impact = Mathf.Sin(time * Mathf.PI * 2f * 110f) * envelope * 0.45f;

            noiseState = 1664525u * noiseState + 1013904223u;
            float noise = ((noiseState & 0xFFFF) / 32767.5f - 1f) * envelope * 0.35f;
            samples[i] = (impact + noise) * envelope;
        }

        AudioClip clip = AudioClip.Create("ProceduralFootstep", sampleCount, 1, sampleRate, false);
        clip.SetData(samples, 0);
        return clip;
    }
}
