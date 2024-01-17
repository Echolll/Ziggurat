using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [Header("����������� ��������������:")]
    [SerializeField]
    public float _maxHealth;
    [SerializeField]
    public float _speed;
    [SerializeField]
    public float _fastAttackDamage;
    [SerializeField]
    public float _strongAttackDamage;
    [Space, Header("��������� �����������:")]
    [SerializeField, Range(0, 100)]
    public float _missProbability;
    [SerializeField, Range(0, 100)]
    public float _doubleDamageProbability;
    [SerializeField, Range(0, 100)]
    public float _probabilityOfStrongOrFastAttack;
}
