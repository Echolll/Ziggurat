using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class BaseClickComponent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField]
    private Material _highlightMaterial;

    [SerializeField]
    private MeshRenderer _gateMaterial;

    public static event Action<Gate> _selectedGate;
    public static event Action _dataGate;

    private Material _defaultMaterial;
    private Gate _gate;

    private void Start()
    {
        _gate = GetComponent<Gate>();
    }

    //Срабатывает при нажатии кнопки мыши на GameObject.
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Кликнули");
        OpenSettnigs();
    }

    //Срабатывает если курсор мыши входит в область GameObject
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Навели");
        SetMaterial();
    }

    //Срабатывает если курсор мыши выходит из области GameObject
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Убрали");
        ResetMaterial();
    }

    private void SetMaterial()
    {
        _defaultMaterial = _gateMaterial.material;

        _gateMaterial.material = _highlightMaterial;
    }

    private void ResetMaterial()
    {
        _gateMaterial.material = _defaultMaterial;
    }

    private void OpenSettnigs()
    {
        _selectedGate?.Invoke(_gate);
        _dataGate?.Invoke();
    }
}
