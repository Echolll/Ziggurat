using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using Ziggurat;

public class MoveAIComponent : MonoBehaviour
{
    [SerializeField] public Transform _targetPosition;
    [SerializeField] public string _firstTagName;
    [SerializeField] public string _secondTagName;
 
    private NavMeshAgent _npcAI;
    private UnitEnvironment _unitAnimation;
    private AttackComponent _attackComponent;

    private void Awake()
    {
        _npcAI = GetComponent<NavMeshAgent>();     
        _unitAnimation = GetComponent<UnitEnvironment>();
        _attackComponent = GetComponent<AttackComponent>();
    }

    private void Start()
    {
        OnMoveToPoint();
    }

    private void Update()
    {
        FindEnemyPosition();
        OnFightTheEnemy();
    }

    private void OnMoveToPoint()
    {
        _npcAI.destination = _targetPosition.gameObject.transform.position;
        _unitAnimation.Moving(_npcAI.speed);
    }

    private void FindEnemyPosition()
    {
        Collider[] _enemyCollider = Physics.OverlapSphere(transform.position, 15f);

        foreach (Collider collider in _enemyCollider) 
        {
           if(collider.CompareTag(_firstTagName) || collider.CompareTag(_secondTagName))
            {
                Unit enemyUnit = collider.GetComponent<Unit>();
                
                if (enemyUnit != null) 
                {                   
                    StartMoveToEnemy(enemyUnit);
                }               
            }
        }
    }

    // Получить позицию рандомного противника и идти к нему
    private void StartMoveToEnemy(Unit currentEnemy)
    {               
        if (currentEnemy != null)
        {                    
            _npcAI.destination = currentEnemy.transform.position;
        }
    }

    private void OnFightTheEnemy()
    {
        Collider[] _enemyCollider = Physics.OverlapSphere(transform.position, 1f);

        foreach (Collider collider in _enemyCollider)
        {
            if (collider.CompareTag(_firstTagName) || collider.CompareTag(_secondTagName))
            {
                Unit enemyUnit = collider.GetComponent<Unit>();

                if (enemyUnit != null)
                {
                    _npcAI.isStopped = true;
                    _unitAnimation.Moving(0);
                     gameObject.transform.LookAt(enemyUnit.gameObject.transform);
                    _attackComponent._probabilityAttack();
                }
                else if (enemyUnit == null)
                {
                    _npcAI.isStopped = false;
                }
            }


        }
    }


}
