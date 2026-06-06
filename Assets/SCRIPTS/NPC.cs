using System;
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

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();

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
}
