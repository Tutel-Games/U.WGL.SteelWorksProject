using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ActivateNextObject : MonoBehaviour
{
    public bool CanInteract = false;
    [SerializeField] private GameObject _objectToActivate;
    [SerializeField] private GameObject _pressToInteractInfo;
    private bool _canShowInfo = false;

    private void Update()
    {
        if (!_canShowInfo) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            ActivateObject();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!CanInteract) return;

        if (col.CompareTag("Player"))
        {
            _pressToInteractInfo.SetActive(true);
            _canShowInfo = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!CanInteract) return;
        
        if (other.CompareTag("Player"))
        {
            _pressToInteractInfo.SetActive(false);
            _canShowInfo = false;
        }
    }

    private void ActivateObject()
    {
        _objectToActivate.GetComponent<ObjectVisualEffects>().enabled = true;
        _objectToActivate.GetComponent<Light2D>().enabled = true;
        _objectToActivate.GetComponent<LoadNextSceneOnInteraction>().enabled = true;
    }
    
}
