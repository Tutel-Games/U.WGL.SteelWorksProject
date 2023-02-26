using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonsCam : MonoBehaviour
{
    [SerializeField] private GameObject _cam;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _pressToInteractInfo;
    private bool _canShowInfo = false;
    
    private void Update()
    {
        if (!_canShowInfo) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            _cam.SetActive(true);
            GetComponent<ObjectVisualEffects>().enabled = false;
            _pressToInteractInfo.SetActive(false);
            transform.localScale = Vector3.one;
            StartCoroutine(LoadScene());
            DOTween.KillAll();
        }
    }

    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1.5f);
        _player.GetComponent<PlayerMovement>().GoDown = true;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("ButtonsGame");
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
