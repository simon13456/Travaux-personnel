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
    [SerializeField] private List<script> _configVague = default;
    private int _vaguedepart = 0;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(EnemyRoutine());
        StartCoroutine(SpawnPowerUpCo());
        StartCoroutine(spawnVague());
    }
    IEnumerator spawnVague()
    {
        while (!_stopaumassacre)
        {
            for (int i = _vaguedepart; i < _configVague.Count; i++)
            {
                script vagueActuel = _configVague[i];
                yield return StartCoroutine(spawnVagueEnnemi(vagueActuel));
                yield return new WaitForSeconds(2f);
            }
        }
    }
    IEnumerator spawnVagueEnnemi(script vague)
    {
        for(int i=0; i< vague.GetNbsEnnemy(); i++)
        {
            GameObject nouveauEnnemi = Instantiate(vague.GetPrefabEnnemy(), vague.GetPointRepere()[0].transform.position, Quaternion.identity);
            nouveauEnnemi.GetComponent<CheminEnnemi>().SetConfigVague(vague);
            yield return new WaitForSeconds(vague.GetTempsSpawn());
        }     
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
        yield return new WaitForSeconds(15f);
        while (!_stopaumassacre)
        {
            
            Vector3 position = new Vector3(UnityEngine.Random.Range(-11f, 11f), 10.5f, 0f);
            int Randpower = UnityEngine.Random.Range(0, _powerUp.Length);
            Instantiate(_powerUp[Randpower], position, Quaternion.identity);
            yield return new WaitForSeconds(10f);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void MortJoueur()
    {
        _stopaumassacre = true;
    }
}
