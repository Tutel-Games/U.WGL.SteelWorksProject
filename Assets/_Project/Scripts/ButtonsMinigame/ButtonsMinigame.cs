using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsMinigame : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private float _timeBtwHighlights;
    [SerializeField] private int _hitsCount;
    [SerializeField] private int _maxHits;
    [SerializeField] private AudioSource _as;
    [SerializeField] private ButtonGameUI _bUI;
    [SerializeField] private GameObject _text;
    private float _timer;
    private System.Random _rnd;
    private int _index;
    private bool _isStarted;
    private void Start()
    {
        _timer = _timeBtwHighlights;
        _rnd = new System.Random();
        foreach (var button in _buttons)
        {
            button.onClick.AddListener(ButtonClick);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isStarted = true;
            _text.SetActive(false);
        }
        
        if (!_isStarted) return;
        
        if (_hitsCount < _maxHits)
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                if (_hitsCount == _maxHits) return;
                HighlightNextButton(GetRandomIndex());
            }
        }
    }

    private int GetRandomIndex()
    {
        int index = _rnd.Next(_buttons.Length);
        return index;
    }

    private void HighlightNextButton(int index)
    {
        if (_hitsCount >= _maxHits) return;
        
        while (index == _index)
        {
            index = GetRandomIndex();
        }
        _buttons[_index].gameObject.SetActive(false);
        _index = index;
        _buttons[index].gameObject.SetActive(true);
        _timer = _timeBtwHighlights;
    }

    private void ButtonClick()
    {
        _as.PlayOneShot(_as.clip);
        _bUI.NextButton();
        if (_hitsCount >= _maxHits)
        {
            
            _buttons[_index].gameObject.SetActive(false);
            return;
        }
        _hitsCount++;
        if (_hitsCount == _maxHits)
        {
            StartCoroutine(LoadNext());
        }
        HighlightNextButton(GetRandomIndex());
    }

    public void StartGame()
    {
        _isStarted = true;
    }

    private IEnumerator LoadNext()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("AfterButtons");
    }
}
