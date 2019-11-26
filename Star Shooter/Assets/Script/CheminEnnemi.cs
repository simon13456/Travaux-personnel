using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheminEnnemi : MonoBehaviour
{
    [SerializeField] private script _configVague;
    private List<Transform> _points;
    private int _indexPointRepere=0;

    public void SetConfigVague(script vagueEnCours)
    {
        this._configVague = vagueEnCours;
    }

    // Start is called before the first frame update
    void Start()
    {
        _points = _configVague.GetPointRepere();
        transform.position = _points[_indexPointRepere].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        mouvementChemin();
    }
    
    private void mouvementChemin()
    {
        if (_indexPointRepere < _points.Count)
        {
            Vector3 targetPosition = _points[_indexPointRepere].transform.position;
            float deplacementPerFrame = _configVague.GetVit() * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, deplacementPerFrame);
            if (transform.position == targetPosition)
            {
                _indexPointRepere++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
