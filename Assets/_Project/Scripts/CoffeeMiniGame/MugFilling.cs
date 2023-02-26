using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MugFilling : MonoBehaviour
{
    [SerializeField] private int _maxHits;
    [SerializeField] private int _currentHits;
    [SerializeField] private TMP_Text _percentageText;
    [SerializeField] private Image _mugImageFill;
    [SerializeField] private GameObject _mugImageFill2;
    [SerializeField] private AudioSource _as;

    public void Hit()
    {
        _as.PlayOneShot(_as.clip);
        if (_currentHits < _maxHits)
        {
            _currentHits++;
            float progressPercentage = (float)_currentHits / _maxHits;
            var sequence = DOTween.Sequence()
                .Append(transform.DOScale(new Vector3(1 + 0.2f, 1 + 0.2f, 1 + 0.2f), .1f))
                .Append(transform.DOScale(1, .1f));
            sequence.Play();
            _mugImageFill2.transform.localScale = new Vector2(1, progressPercentage);
            _mugImageFill.DOFillAmount(progressPercentage, 0.15f);
            _percentageText.text = $"{progressPercentage * 100}%";
        }
        else
        {
            SceneManager.LoadScene("AfterCoffee");
        }
    }
}
