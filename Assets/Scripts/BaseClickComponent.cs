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

    [SerializeField]
    private SkinnedMeshRenderer _unitMeshRenderer;

    public static event Action<Gate> _selectedGate;
    public static event Action _dataGate;
    public static event Action<Unit> _selectedUnit;
    public static event Action _dataUnit;

    private Material _defaultMaterial;
    private Gate _gate;
    private Unit _unit;

    private void Start()
    {
        _gate = GetComponent<Gate>();
        _unit = GetComponent<Unit>();
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
        if (_gateMaterial != null)
        {
            _defaultMaterial = _gateMaterial.material;
            _gateMaterial.material = _highlightMaterial;
        }
        else if (_unitMeshRenderer != null)
        {
            _defaultMaterial = _unitMeshRenderer.material;
            _unitMeshRenderer.material = _highlightMaterial;
        }
    }

    private void ResetMaterial()
    {
        if (_gateMaterial != null)
        {
            _gateMaterial.material = _defaultMaterial;
        }
        else if (_unitMeshRenderer != null)
        {
            _unitMeshRenderer.material = _defaultMaterial;
        }
    }

    private void OpenSettnigs()
    {
        if (_gateMaterial != null)
        {
            _selectedGate?.Invoke(_gate);
            _dataGate?.Invoke();
            Debug.Log("А-а-а");
        }
        else if( _unitMeshRenderer != null)
        {
            _selectedUnit?.Invoke(_unit);
            _dataUnit?.Invoke();
        }
    }
}
