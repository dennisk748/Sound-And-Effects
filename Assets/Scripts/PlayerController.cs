using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody Rigidbody;
    private Animator Animator;
    private AudioSource audioSource;
    [SerializeField] private ParticleSystem feetDust;
    [SerializeField] private ParticleSystem fallcloud;


    [SerializeField] private AudioClip[] clips;
    [SerializeField] private float force;
    [SerializeField] private float timeToPlay;
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private float gravityModifier;
    public bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Animator = GetComponent<Animator>();
        Rigidbody = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        Animator.SetFloat("Speed_f", 1f);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isGameOver)
        {
            feetDust.Stop();
            audioSource.PlayOneShot(clips[0], 1.0f);
            Rigidbody.AddForce(Vector3.up * force, ForceMode.Impulse);
            isGrounded = false;
            Animator.SetTrigger("Jump_trig");
        }
        else
        {
            Animator.SetBool("Jump_b",false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            feetDust.Play();
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            feetDust.Stop();
            Animator.SetBool("Death_b", true);
            Animator.SetInteger("DeathType_int", 1);
            isGameOver = true;
            Invoke("PlayExplosion", timeToPlay);
        }
    }
    private void PlayExplosion()
    {
        audioSource.PlayOneShot(clips[2], 1.0f);
        fallcloud.Play();
    }
}
