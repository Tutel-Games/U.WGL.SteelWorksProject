using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DialogueWriter : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private DialogueSO _dialogue;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private TMP_Text _pressSpaceText;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject _objectToActivate;


    private IEnumerator Start()
    {
        yield return new WaitForSeconds(_delay);
        _canvas.gameObject.SetActive(true);
        StartCoroutine(WriteText());
    }

    private IEnumerator WriteText()
    {
        foreach (char c in _dialogue.Text)
        {
            _audioSource.Play();
            _text.text += c;
            yield return new WaitForSeconds (0.05f);
        }
        _pressSpaceText.gameObject.SetActive(true);
        var sequence = DOTween.Sequence()
            .Append(_pressSpaceText.transform.DOScale(new Vector3(0.8f + 0.2f, 0.8f + 0.2f, 0.8f + 0.2f), .5f))
            .Append(_pressSpaceText.transform.DOScale(0.8f, .5f))
            .SetLoops(-1);
        sequence.Play();
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        _canvas.gameObject.SetActive(false);
        _objectToActivate.SetActive(true);
        _objectToActivate.GetComponent<ObjectVisualEffects>().enabled = true;
        if (_objectToActivate.GetComponent<Light2D>())
        {
            _objectToActivate.GetComponent<Light2D>().enabled = true;
        }

        if (_objectToActivate.GetComponent<ActivateNextObject>())
        {
            _objectToActivate.GetComponent<ActivateNextObject>().CanInteract = true;
        }
    }
}
