using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUnits : MonoBehaviour
{
    private void Start()
    {
        Gate gt = GetComponent<Gate>();
        if (gt == null)
        {         
            Debug.Log("Нет сыллки на объект");
        }
        
    }
}
