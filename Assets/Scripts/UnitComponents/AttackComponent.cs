using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ziggurat;

public class AttackComponent : MonoBehaviour
{
    [SerializeField] private GameObject _sword;
   
    private float _fastAttackDamage; 
    private float _strongAttackDamage;
    private float _missProbability;
    private float _doubleDamageProbability;
    private float _probabilityOfStrongOrFastAttack;

    private Unit _unitAttributies;
    private UnitEnvironment _unitAnimation;
    private MoveAIComponent _tagsEnemy;
    private MoveAIComponent _attackAI;

   
    void Start()
    {
        _unitAttributies = GetComponent<Unit>();
        _unitAnimation = GetComponent<UnitEnvironment>();
        _tagsEnemy = GetComponent<MoveAIComponent>();
        _attackAI = GetComponent<MoveAIComponent>();
    }

    void LateUpdate()
    {
        DataInitialization();
    }

    private void DataInitialization()
    {
        _fastAttackDamage = _unitAttributies._fastAttackDamage;
        _strongAttackDamage = _unitAttributies._strongAttackDamage;
        _missProbability = _unitAttributies._missProbability;
        _doubleDamageProbability = _unitAttributies._doubleDamageProbability;
        _probabilityOfStrongOrFastAttack = _unitAttributies._probabilityOfStrongOrFastAttack;
    }
   
    public void _probabilityAttack()
    {
        float radomMiss = UnityEngine.Random.Range(0, 100);
        float radomAttack = UnityEngine.Random.Range(0, 100);
        if (radomMiss < _missProbability)
        {
            if(radomAttack < _probabilityOfStrongOrFastAttack)
            {
                OnStrongAttack();
            }
            else if (radomAttack > _probabilityOfStrongOrFastAttack) 
            {
                OnFastAttack();
            }
        }
        else 
        {
            Debug.Log("Промах");
            return;
        }
    }

    private void OnFastAttack()
    {
        _unitAnimation.StartAnimation("Fast");
        _sword.GetComponent<DamageComponent>().DataInitialization(_fastAttackDamage, _attackAI._firstTagName, _attackAI._secondTagName);
    }

    private void OnStrongAttack()
    {
        float doubleDamage =  UnityEngine.Random.Range(0, 100);
        _unitAnimation.StartAnimation("Strong");

        if(doubleDamage > _doubleDamageProbability)
        {
            float damage = _strongAttackDamage * 2;
            _sword.GetComponent<DamageComponent>().DataInitialization(damage, _attackAI._firstTagName, _attackAI._secondTagName);
        }
        else
        {
            _sword.GetComponent<DamageComponent>().DataInitialization(_strongAttackDamage, _attackAI._firstTagName, _attackAI._secondTagName);
        }

    }
}
