using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneEnd : MonoBehaviour
{
    [SerializeField] private GameObject _cam;
    [SerializeField] private ParticleSystem _explosionParticles;
    [SerializeField] private AudioSource _as;
    
    public void CameraChange()
    {
        AudioSource.PlayClipAtPoint(_as.clip, transform.position);
        ParticleSystem explosion = Instantiate(_explosionParticles, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
        explosion.Play();
        _cam.SetActive(false);
        Destroy(gameObject);
    }
    
}
