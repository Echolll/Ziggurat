using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ziggurat;

public class HealthComponent : MonoBehaviour
{
    private float _maxHealth;

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

    private void TakeDamage()
    {

    }

    private void OnDeath()
    {

    }
}
