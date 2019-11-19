using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    private bool _stopaumassacre=false;
    [SerializeField] private GameObject _enemyPrefab = default;
    [SerializeField] private GameObject[] _powerUp = default;
    [SerializeField] private float delay = 3f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyRoutine());
        StartCoroutine(SpawnPowerUpCo());
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
    IEnumerator SpawnPowerUpCo()
    {
        //yield return new WaitForSeconds(15f);
        while (!_stopaumassacre)
        {
            
            Vector3 position = new Vector3(UnityEngine.Random.Range(-11f, 11f), 10.5f, 0f);
            int Randpower = UnityEngine.Random.Range(0, _powerUp.Length);
            Instantiate(_powerUp[Randpower], position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
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
