using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Vague ennemi") ]
public class script : ScriptableObject
{
    [SerializeField] private GameObject _path = default;
    [SerializeField] private GameObject _ennemi = default;
    [SerializeField] private float _delay=5f;
    [SerializeField] private float _vitesse = 5f;
    [SerializeField] private int _nbsennemi = 6;


    public GameObject GetPrefabEnnemy() { return _ennemi; }
    public float GetTempsSpawn() { return _delay; }
    public float GetVit() { return _vitesse; }
    public int GetNbsEnnemy() { return _nbsennemi; }



    public List<Transform> GetPointRepere()
    {
        List<Transform> PointDeRepere = new List<Transform>();
        foreach(Transform point in _path.transform)
        {
            PointDeRepere.Add(point);
        }
        return PointDeRepere;
    }
}
