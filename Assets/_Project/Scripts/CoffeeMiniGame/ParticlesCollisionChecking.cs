using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesCollisionChecking : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Mug"))
        {
            other.GetComponent<MugFilling>().Hit();
        }
    }
}
