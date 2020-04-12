using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionHendler : MonoBehaviour
{
    private ParticleSystem hitParticles;
    void Start()
    {
        hitParticles = GetComponentInChildren<ParticleSystem>();
    }

    void HitParticles()
    {
        
        hitParticles.Play();
    }
}
