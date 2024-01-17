using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Ziggurat;

public class MoveAIComponent : MonoBehaviour
{
    [SerializeField] private Transform _targetPosition;

    private NavMeshAgent _npcAI;
    private UnitEnvironment _unitAnimation;

    private void Awake()
    {
        _npcAI = GetComponent<NavMeshAgent>();     
        _unitAnimation = GetComponent<UnitEnvironment>();
    }

    private void Start()
    {
        OnMoveToPoint();
    }

    private void FixedUpdate()
    {
        FlagDistance();
    }

    private void FlagDistance()
    {     
        bool isFlag = ShouldStopNavigation();

        if (isFlag) 
        {
            _npcAI.isStopped = true;
            _unitAnimation.Moving(0);           
        }
    }

    bool ShouldStopNavigation()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 10f);

        foreach (Collider collider in colliders) 
        {
            if(collider.CompareTag("Flag"))
            {
                return true;
            }
        }

        return false;
    }

    private void OnMoveToPoint()
    {
        _npcAI.destination = _targetPosition.position;
        _unitAnimation.Moving(_npcAI.speed);
    }

}
