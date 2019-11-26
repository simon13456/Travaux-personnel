using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemi : MonoBehaviour
{
    [SerializeField] private float _speed=3f;
    [SerializeField] private GameObject _LaserPrefab = default;
    [SerializeField] private GameObject _explosion = default;
    private bool tjrvrai=true;
    private UIManager _uImanager = default;

    // Start is called before the first frame update
    void Start()
    {
        _uImanager = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        int rand = (int)(UnityEngine.Random.Range(0f, 10000f));
        if (rand <= 1 && tjrvrai)
        {
            StartCoroutine(Lazer());  
        }
    }
    IEnumerator Lazer()
    {
        Instantiate(_LaserPrefab, transform.position + new Vector3(0f, -2f, 0f), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);;
    }
    private void mouvement()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
        if(transform.position.y <= -5.5f)
        {
            float randomx = UnityEngine.Random.Range(12.5f, -12.5f);
            transform.position = new Vector3(randomx, 14f, 0f);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "lazer")
        {
            // Destroy(other.gameObject);
            //Destroy(other.gameObject);
            Destroy(this.gameObject);
            Instantiate(_explosion, transform.position, Quaternion.identity);
            _uImanager.AjouterScore(100);
        }
        else if (other.tag == "Player")
        {
            Joueur joueur = other.transform.GetComponent<Joueur>();
            joueur.dammage();
            Destroy(this.gameObject);
            Instantiate(_explosion, transform.position, Quaternion.identity);
        }
    }
}
