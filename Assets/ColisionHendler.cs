using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionHendler : MonoBehaviour
{
    
    [SerializeField] ParticleSystem hitParticles;
    void Start()
    {
        
    }

    void HitParticles()
    {
        
        hitParticles.Play();
    }
}
