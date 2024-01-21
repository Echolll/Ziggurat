using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    [SerializeField]
    private string _firstEnemy;
    [SerializeField]
    private string _secondEnemy;

    [SerializeField]
    private float _damage;

    public void DataInitialization(float damage,string firstEnemy,string secondEnemy)
    {
        _firstEnemy = firstEnemy;
        _secondEnemy = secondEnemy;
        _damage = damage;
    }

    private void OnTriggerEnter(Collider other)
    {       
       if (other.gameObject.CompareTag(_firstEnemy) || other.gameObject.CompareTag(_secondEnemy))
       {
            if (!other.gameObject.CompareTag("Untagged"))
            {
                HealthComponent enemyHealth = other.GetComponent<HealthComponent>();
                enemyHealth.TakeDamage(_damage);
                Debug.Log($"{enemyHealth.gameObject} получил урон {_damage}");
            }
            else { return; }
        }     
    }   
}
