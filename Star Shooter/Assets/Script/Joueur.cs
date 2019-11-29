using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur : MonoBehaviour
{
    [SerializeField] private GameObject _LaserPrefab = default;
    [SerializeField] private GameObject _tripleLaserPrefab = default;
    [SerializeField] float vit = 10;
    [SerializeField] private int _viesjoueur = 3;
    [SerializeField] private bool _tripleshot;
    [SerializeField] private GameObject _explosion = default;
    [SerializeField] private bool _vieInfini=false;
    private GameObject _shield = default;
    private GameObject _tripleyolo = default;
    private spawn _spawnmangaer = default;
    private UIManager _uImanager = default;
    private Animator _anim;
    private bool _shieldActive;
    private int _compteur = 2;
    private bool fire;
    


    // Start is called before the first frame update
    void Start()
    {
        _shield = transform.GetChild(0).gameObject;
       _tripleyolo = transform.GetChild(1).gameObject;
        transform.position = new Vector3(0f, -5.51f, 0f);
        _spawnmangaer = GameObject.Find("Spawn_Mannager").GetComponent<spawn>();
        _uImanager = FindObjectOfType<UIManager>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Deplacement();
        UpdateFire();
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _anim.SetBool("turnLeft", true);
            _anim.SetBool("turnRight", false);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _anim.SetBool("turnLeft", false);
            _anim.SetBool("turnRight", false);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _anim.SetBool("turnLeft", false);
            _anim.SetBool("turnRight", true);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            _anim.SetBool("turnLeft", false);
            _anim.SetBool("turnRight", false);
        }
    }

    private void UpdateFire()
    {
        if (fire)
        {
            Fire(0f, 1f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_tripleshot == false)
            {
                Fire(0f, 1f, 0f);
            }
            else
            {
                Fire(0f, 1f, 0f, _tripleLaserPrefab);
            }

        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            for (float i = -15f; i <= 15f; i = i + 0.1f)
            {
                Fire(i, 0f, 0f);
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Fire(0f, 1f, 0f, _tripleLaserPrefab);
        }
        if (Input.GetKeyDown(KeyCode.F) && (_compteur % 2 == 0))
        {
            fire = true;
            _compteur++;
        }
        else if (Input.GetKeyDown(KeyCode.F) && (_compteur % 2 == 1))
        {
            fire = false;
            _compteur++;
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
        if (!_shieldActive && !_vieInfini)
        {
            _viesjoueur--;
            if (_viesjoueur < 1 )
            {
                Destroy(this.gameObject);
                Instantiate(_explosion, transform.position, Quaternion.identity);
                _spawnmangaer.MortJoueur();
            }
            _uImanager.ChangeLivesDisplayImage(_viesjoueur);
        }
        else
        {
            _shieldActive = false;
            _shield.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "lazerennemy")
        {
            Destroy(other.gameObject);
            dammage();
        }
    }
    public void tripleShot()
    {
        
        StartCoroutine(tripleShotco());
    }
    IEnumerator tripleShotco()
    {
        _tripleshot = true;
        for (int i=0; i <= 150; i++)
        {
           _tripleyolo.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.1f);
          _tripleyolo.gameObject.SetActive(false);
           yield return new WaitForSeconds(0.1f);
          }
          _tripleshot = false;
       
    }
    public void speed()
    {
        StartCoroutine(speedco());
    }
    IEnumerator speedco()
    {
        float vitini = vit;
        vit = vitini*2;
        yield return new WaitForSeconds(10f);
        vit = vitini;
    }
    public void Shield()
    {
        _shieldActive = true;
        _shield.SetActive(true);
    }
    private void Fire(float i, float j, float k)
    {
        Instantiate(_LaserPrefab, transform.position + new Vector3(i, j, k), Quaternion.identity);
    }
    private void Fire(float i, float j, float k, GameObject laser)
    {
        Instantiate(laser, transform.position + new Vector3(i, j, k), Quaternion.identity);
    }
}
