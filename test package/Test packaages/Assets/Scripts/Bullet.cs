using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform _target = null;
    [SerializeField] private float _speed = 30f;
    [SerializeField] private GameObject _gunShotFX;
    private float bulletSpeed;
    private Vector3 _direction;

    public void Seek (Transform target) {
        _target = target;
    }

    public void Start() {
        _direction = _target.position - transform.position;
        Instantiate(_gunShotFX, transform.position, transform.rotation);
        //Faire du son aussi
    }

    // Update is called once per frame
    void Update() {
        if (_target==null) {
            Destroy(gameObject);
            return;
        }
        bulletSpeed = _speed * Time.deltaTime;
        transform.Translate(_direction.normalized * bulletSpeed, Space.World);

        /*
        if (Bullet frappe le fons ou dequoi dautre) {
            Destroy(gameObject);
        }*/
    }
}
