using System;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] Transform goalPostion;

    [SerializeField] ParticleSystem particle;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(goalPostion.position);
    }

    public void playParticle()
    {
        particle.Play();
    }
}
