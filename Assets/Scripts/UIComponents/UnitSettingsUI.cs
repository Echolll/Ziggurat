using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitSettingsUI : MonoBehaviour
{
    [SerializeField]
    private Unit _unitSettings;

    [SerializeField] private TMP_InputField _maxHealth;
    [SerializeField] private TMP_InputField _speed;
    [SerializeField] private TMP_InputField _fastAttackDamage;
    [SerializeField] private TMP_InputField _strongAttackDamage;
    [SerializeField] private TMP_InputField _missProbability;
    [SerializeField] private TMP_InputField _doubleDamageProbability;
    [SerializeField] private TMP_InputField _probabilityOfStrongOrFastAttack;

    AnimationUI _animUI;

    private void Awake()
    {
        _animUI = GetComponent<AnimationUI>();
    }

    private void OnEnable()
    {
        BaseClickComponent._selectedUnit += GetUnitAttributes;
        BaseClickComponent._dataUnit += DataReference;
    }

    private void OnDisable()
    {
        BaseClickComponent._selectedUnit -= GetUnitAttributes;
        BaseClickComponent._dataUnit -= DataReference;
    }

    private void FixedUpdate()
    {
        ChangeData(_unitSettings);
    }

    private void DataReference()
    {
        if (_unitSettings != null)
        {
            _maxHealth.text = _unitSettings._maxHealth.ToString();
            _speed.text = _unitSettings._speed.ToString();
            _fastAttackDamage.text = _unitSettings._fastAttackDamage.ToString();
            _strongAttackDamage.text = _unitSettings._strongAttackDamage.ToString();
            _missProbability.text = _unitSettings._missProbability.ToString();
            _doubleDamageProbability.text = _unitSettings._doubleDamageProbability.ToString();
            _probabilityOfStrongOrFastAttack.text = _unitSettings._probabilityOfStrongOrFastAttack.ToString();
        }
    }

    private void ChangeData(Unit _data)
    {
        if (_data != null)
        {
            _data._maxHealth = float.Parse(_maxHealth.text);
            _data._speed = float.Parse(_speed.text);
            _data._fastAttackDamage = float.Parse(_fastAttackDamage.text);
            _data._strongAttackDamage = float.Parse(_strongAttackDamage.text);
            _data._missProbability = float.Parse(_missProbability.text);
            _data._doubleDamageProbability = float.Parse(_doubleDamageProbability.text);
            _data._probabilityOfStrongOrFastAttack = float.Parse(_probabilityOfStrongOrFastAttack.text);
        }
    }

    private void GetUnitAttributes(Unit _unitData)
    {
        _unitSettings = _unitData;
        if (_animUI != null)
        {
            _animUI.OpenUI();
        }
    }
}
