using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class SpawnUnits : MonoBehaviour
{
    [SerializeField] Transform _spawnPoint;
    [SerializeField] Transform _firstTarget;
    [SerializeField] GameObject _unit;

    private float _timeToSpawn;

    Gate _gate;

    private void Awake()
    {
        _gate = GetComponent<Gate>();
    }

    private void Start()
    {
        ResetTime();
    }

    private void ResetTime()
    {
        _timeToSpawn = _gate._timeToSpawnUnit;
    }

    private void Update()
    {
        OnSpawnUnits();
    }

    private void OnSpawnUnits()
    {
        _timeToSpawn -= Time.deltaTime;
        if( _timeToSpawn <= 0 ) 
        {
            SpawnUnit();
            ResetTime();
        }      
    }

    private void SpawnUnit()
    {
       GameObject obj = Instantiate(_unit, _spawnPoint.position, Quaternion.identity);
       obj.transform.SetParent(_spawnPoint);
       Unit unitSettings = obj.GetComponent<Unit>();
       MoveAIComponent _target = obj.GetComponent<MoveAIComponent>();
        _target._targetPosition = _firstTarget;
        unitSettings._maxHealth = _gate._maxHealth;
        unitSettings._speed = _gate._speed;
        unitSettings._fastAttackDamage = _gate._fastAttackDamage;
        unitSettings._strongAttackDamage = _gate._strongAttackDamage;
        unitSettings._missProbability = _gate._missProbability;
        unitSettings._doubleDamageProbability = _gate._doubleDamageProbability;
        unitSettings._probabilityOfStrongOrFastAttack = _gate._probabilityOfStrongOrFastAttack;
    }

    

    
}
