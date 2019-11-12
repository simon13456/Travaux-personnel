using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    private bool _stopaumassacre=false;
    [SerializeField] private GameObject _enemyPrefab = default;
    [SerializeField] private float delay = 3f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyRoutine());
    }
    IEnumerator EnemyRoutine()
    {
        while (!_stopaumassacre)
        {
            
            Vector3 position=new Vector3 (UnityEngine.Random.Range(-11f, 11f), 10.5f, 0f);
            Instantiate(_enemyPrefab,position,Quaternion.identity);
            yield return new WaitForSeconds(delay);
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    internal void MortJoueur()
    {
        _stopaumassacre = true;
        
    }
}
