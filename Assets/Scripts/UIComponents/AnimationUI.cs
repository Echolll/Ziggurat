using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationUI : MonoBehaviour
{
    [Header("Анимация UI:")]
    [SerializeField] private Button _closeUIElement;
    [SerializeField] private RectTransform _panelRectTransform;
    [SerializeField] private Vector2 _firstPos;
    [SerializeField] private Vector2 _secondPos;
    [SerializeField,Range(50,150)] private float _moveTime;
    [SerializeField] private bool isMoving = false;
   
    private void OnEnable()
    {
        _closeUIElement.onClick.AddListener(CloseUI);
    }

    private void OnDisable()
    {
        _closeUIElement.onClick.RemoveListener(CloseUI);
    }

    private void CloseUI()
    {
        StartCoroutine(StartCloseAnimation());
    }

    internal void OpenUI()
    {       
        StartCoroutine(StartOpenAnimation());
    }

    private IEnumerator StartCloseAnimation()
    {
        if (isMoving)
        {
            yield break;
        }

        isMoving = true;

        Vector2 _startPos = _panelRectTransform.anchoredPosition;

        float elapsedTime = 0f;

        while(elapsedTime < _moveTime)
        {
            elapsedTime += Time.time;

            elapsedTime = Mathf.Min(elapsedTime, _moveTime);
            float t = elapsedTime / _moveTime;

            _panelRectTransform.anchoredPosition = Vector2.Lerp(_startPos, _firstPos, t);
            yield return null;
        }

        _panelRectTransform.anchoredPosition = _firstPos;
        isMoving = false;
    }

    private IEnumerator StartOpenAnimation()
    {
        if (isMoving)
        {
            yield break;
        }

        isMoving = true;

        Vector2 _startPos = _panelRectTransform.anchoredPosition;

        float elapsedTime = 0f;

        while (elapsedTime < _moveTime)
        {
            elapsedTime += Time.time;

            elapsedTime = Mathf.Min(elapsedTime, _moveTime);
            float t = elapsedTime / _moveTime;

            _panelRectTransform.anchoredPosition = Vector2.Lerp(_startPos, _secondPos, t);
            yield return null;
        }

        _panelRectTransform.anchoredPosition = _secondPos;     
        isMoving = false;
    }
}
