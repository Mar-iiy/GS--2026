using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField] Transform goalPostion;
    
    [Header("Particula")]
    [SerializeField] ParticleSystem particle;

    [Header("Animation")]
    [SerializeField] private Animator animator;

    [Header("AUDIO")]
    [SerializeField] private AudioClip audioLatido;
    [SerializeField] AudioSource audio;

    private Outline outline;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        outline = GetComponent<Outline>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        agent.SetDestination(goalPostion.position);

        bool isMoving = agent.velocity.sqrMagnitude > 0.01f;

        if (isMoving)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }

    public void playParticle()
    {
        particle.Play();
    }

    public void PlaySound()
    {
        if (!audio.isPlaying)
        {
                audio.clip = audioLatido;
                audio.Play();
        }
        else
        {
            audio.Stop();
        }
    }
}
