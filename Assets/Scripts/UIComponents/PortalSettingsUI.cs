using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class PortalSettingsUI : MonoBehaviour
{
    [SerializeField]
    private Gate _gateSettings;

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
        BaseClickComponent._selectedGate += GetGatesAttributes;
        BaseClickComponent._dataGate += DataReference;
    }

    private void OnDisable()
    {
        BaseClickComponent._selectedGate -= GetGatesAttributes;
        BaseClickComponent._dataGate -= DataReference;
    }

    private void FixedUpdate()
    {
        ChangeData(_gateSettings);
    }

    private void DataReference()
    {
        if (_gateSettings != null)
        {
            _maxHealth.text = _gateSettings._maxHealth.ToString();
            _speed.text = _gateSettings._speed.ToString();
            _fastAttackDamage.text = _gateSettings._fastAttackDamage.ToString();
            _strongAttackDamage.text = _gateSettings._strongAttackDamage.ToString();
            _missProbability.text = _gateSettings._missProbability.ToString();
            _doubleDamageProbability.text = _gateSettings._doubleDamageProbability.ToString();
            _probabilityOfStrongOrFastAttack.text = _gateSettings._probabilityOfStrongOrFastAttack.ToString();
        }    
    }

    private void ChangeData(Gate _data)
    {
        if( _data != null ) 
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

    private void GetGatesAttributes(Gate _gate)
    {
        _gateSettings = _gate;
        if (_animUI != null)
        {           
            _animUI.OpenUI();
        }
    }   
}
