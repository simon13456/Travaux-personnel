﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur : MonoBehaviour
{
    [SerializeField] private GameObject _LaserPrefab =default;
    [SerializeField] float vit = 10;
    [SerializeField] private int _viesjoueur=3;
    private spawn _spawnmangaer=default;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f, -5.51f, 0f);
        _spawnmangaer = GameObject.Find("Spawn_Mannager").GetComponent<spawn>();
    }

    // Update is called once per frame
    void Update()
    {
        Deplacement();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_LaserPrefab, transform.position + new Vector3(0f, 1f ,0f), Quaternion.identity);
        }
    }

    private void Deplacement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, VerticalInput, 0f);
        transform.Translate(direction * Time.deltaTime * vit);
        if (transform.position.x >= 14.3f)
        {
            transform.position = new Vector3(-14.3f, transform.position.y, 0f);
        }
        else if (transform.position.x <= -14.3f)
        {
            transform.position = new Vector3(14.3f, transform.position.y, 0f);
        }
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -6.68f, 6.73f), transform.position.z);
    }
    public void dammage()
    {
        _viesjoueur--;
        if (_viesjoueur < 1)
        {
            Destroy(this.gameObject);
            _spawnmangaer.MortJoueur();
        }
    }
}
