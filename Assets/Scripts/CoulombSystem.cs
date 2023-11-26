using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CoulombSystem : MonoBehaviour
{
    public float charge = 1f; 
    void FixedUpdate()
    {
        ApplyForce();
    }
    private void ApplyForce()
    {
        CoulombSystem[] particles = FindObjectsOfType<CoulombSystem>();
        foreach (CoulombSystem otherParticle in particles)
        {
            if (otherParticle != this)
            {
                Vector3 direction = otherParticle.transform.position - transform.position;
                float distance = direction.magnitude;
                if (distance == 0)
                    continue; 
                float forceMagnitude = ( charge * otherParticle.charge) / (distance * distance);
                Vector3 force = forceMagnitude * direction.normalized;
                Rigidbody rb = GetComponent<Rigidbody>();
                rb.AddForce(force);
            }
        }
    }
}
