using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ziggurat;

public class AttackComponent : MonoBehaviour
{
    private float _fastAttackDamage; 
    private float _strongAttackDamage;
    private float _missProbability;
    private float _doubleDamageProbability;
    private float _probabilityOfStrongOrFastAttack;

    private Unit _unitAttributies;
    private UnitEnvironment _unitAnimation;

    void Start()
    {
        _unitAttributies = GetComponent<Unit>();
        _unitAnimation = GetComponent<UnitEnvironment>();
    }

    void Update()
    {
        
    }

    private void OnFastAttack()
    {

    }

    private void OnStrongAttack()
    {
        
    }
}
