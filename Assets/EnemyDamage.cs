using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    
    [SerializeField] int hitPOints =3;
    [SerializeField] private ParticleSystem deathParticals;
    
    
    
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        hitPOints -= 1;
        SendMessage("HitParticles");

        if (hitPOints == 0)
        {
            Instantiate(deathParticals, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
          
    }
  
}
