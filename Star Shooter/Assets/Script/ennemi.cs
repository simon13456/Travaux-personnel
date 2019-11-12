using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemi : MonoBehaviour
{
    [SerializeField] private float _speed=5f;
    [SerializeField] private GameObject _LaserPrefab = default;
    private bool tjrvrai=true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Lazer());
    }

    // Update is called once per frame
    void Update()
    {
        mouvement();

    }
    IEnumerator Lazer()
    {
        while (tjrvrai)
        {
            int rand = (int)(UnityEngine.Random.Range(0f, 100f));
            if (rand <= 10) {
                Instantiate(_LaserPrefab, transform.position + new Vector3(0f, -1f, 0f), Quaternion.identity);
            }
            else
            {
                new WaitForSeconds(4f);
            }
        }
        yield return 0;
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
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "lazer")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else if (other.tag == "Player")
        {
            Joueur joueur = other.transform.GetComponent<Joueur>();
            joueur.dammage();
            Destroy(this.gameObject);
        }
    }
}
