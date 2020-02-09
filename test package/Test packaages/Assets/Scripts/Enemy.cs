using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [Header("GameObjects")]
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _playerHead;
    [SerializeField] private Transform _head;
    [SerializeField] private Transform _partToRotate;

    [SerializeField] private Animator _anim;
    private bool isVisible = true;

    [Header("Tir")]
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _fireRate = 1f;
    private float _fireCountDown = 0f;

    // Start is called before the first frame update
    void Start() {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (isVisible && _fireCountDown<=0f) {
            //_anim.SetBool("isFiring", true);
            Shoot();
            _fireCountDown = 1f / _fireRate;
        }
        else {
            //_anim.SetBool("isFiring", false);
        }
        _fireCountDown -= Time.deltaTime;

        Vector3 direction = _playerHead.position - _head.position;
        _partToRotate.rotation = Quaternion.LookRotation(direction);
        _partToRotate.rotation *= Quaternion.Euler(0f, 90f, -90f);
    }

    private void Shoot() {
        GameObject bulletGO = (GameObject)Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null) {
            bullet.Seek(_target);
        }

    }
}
