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

    

    public void TakeDamage(float damage)
    {
        if(_maxHealth > 0)
        {
            _maxHealth -= damage;
            _unitAnimation.StartAnimation("Impact");
            Debug.Log("Урон получен");
        }
        else if (_maxHealth <= 0)
        {
            OnDeath();
            Debug.Log("Помер");
        }
    }

    private void OnDeath()
    {
       Destroy(gameObject);
        _unitAnimation.StartAnimation("Die");
    }
}
