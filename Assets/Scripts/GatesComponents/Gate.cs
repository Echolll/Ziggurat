using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [Header("(Необязательно) Данные для портала:")]
    [SerializeField] private GatesAttributes _gatesData;

    [Header("Стандартные характеристики:")]
    [SerializeField]
    public float _maxHealth;
    [SerializeField]
    public float _speed;
    [SerializeField]
    public float _fastAttackDamage;
    [SerializeField]
    public float _strongAttackDamage;
    [Space, Header("Настройка вероятности:")]
    [SerializeField, Range(0, 100)]
    public float _missProbability;
    [SerializeField, Range(0, 100)]
    public float _doubleDamageProbability;
    [SerializeField, Range(0, 100)]
    public float _probabilityOfStrongOrFastAttack;

    [Space, Header("Время до создания юнита:")]
    [SerializeField]
    [Range(1,10)] public float _timeToSpawnUnit;


    private void Start()
    {
        if(_gatesData != null)
        {
            OnStartData(_gatesData);
        }
    }

    private void OnStartData(GatesAttributes _data)
    {
        _maxHealth = _data._maxHealth;
        _speed = _data._speed;
        _fastAttackDamage = _data._fastAttackDamage;
        _strongAttackDamage = _data._strongAttackDamage;
        _missProbability = _data._missProbability;
        _doubleDamageProbability = _data._doubleDamageProbability;
        _probabilityOfStrongOrFastAttack = _data._probabilityOfStrongOrFastAttack;
    }
}
