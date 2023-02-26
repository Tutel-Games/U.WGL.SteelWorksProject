using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class StartPaperworkCam : MonoBehaviour
{
    [SerializeField] private GameObject _cam;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _pressToInteractInfo;
    private bool _canShowInfo = false;
    private Vector3 _startScale;
    private void Start()
    {
        _startScale = transform.localScale;
    }

    private void Update()
    {
        if (!_canShowInfo) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            _cam.SetActive(true);
            GetComponent<ObjectVisualEffects>().enabled = false;
            _pressToInteractInfo.SetActive(false);
            transform.localScale = _startScale;
            GetComponent<Light2D>().enabled = false;
            StartCoroutine(LoadScene());
            DOTween.KillAll();
        }
    }

    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1.5f);
        _player.GetComponent<PlayerMovement>().GoDown = true;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("PaperworkGame");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _pressToInteractInfo.SetActive(true);
            _canShowInfo = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            _pressToInteractInfo.SetActive(false);
            _canShowInfo = false;
        }
    }
}