using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBarrelGun : MonoBehaviour, IWeapon
{
    private float _damage = 20f;
    private float _range = 20f;
    private int _magazineSize = 2;
    private int _ammoInMagazine;
    private int _ammoInInventory = 18;
    private Camera PlayerCamera;
    private RaycastHit _hit;
    private float _headDamageRate = 1.5f;
    public bool _allowShooting = true;

    public AudioSource AudioSource;
    public AudioClip ShootAudio;
    public AudioClip ReloadAudio;
    public ParticleSystem ShootEffect;
    //private Animation _animation;

    private float _minFireDispersion = -6f;
    private float _maxFireDispersion = 6f;
    private Transform _firePointStartTransform;

    public bool IsActive;
    public GameObject Mesh;
    
    public void Initialize()
    {
        //_animation = GetComponent<Animation>();
        _ammoInMagazine = _magazineSize;
        Remove();
        PlayerCamera = PlayerController.Singleton.Camera;
        _firePointStartTransform = PlayerCamera.transform;
    }

    public void Reload()
    {
        if (IsActive == false)
            return;

        AudioSource.PlayOneShot(ReloadAudio);
        //_animation.Play("Reload");
        var ammoDiference = _magazineSize - _ammoInMagazine;
        if (ammoDiference > _ammoInInventory)
            ammoDiference = _ammoInInventory;
        _ammoInInventory -= ammoDiference;
        _ammoInMagazine += ammoDiference;
    }

    public void Remove()
    {
        IsActive = false;
        Mesh.SetActive(false);
    }

    public void Shot()
    {
        if (IsActive == false)
            return;
        //animator.SetTrigger("Shoot");
        AudioSource.PlayOneShot(ShootAudio);
        //_animation.Play("Shoot");
        for (int bulletCounter = 7; bulletCounter > 0; bulletCounter--)
        {
            if(Physics.Raycast(PlayerCamera.transform.position, GetShootDirection(), out _hit, _range))
            {
                IEnemy enemy = _hit.transform.GetComponentInParent<IEnemy>();
                Debug.Log($"enemy is <color=yellow> {enemy} </color> ->   Hit to <color=yellow> {_hit.collider.name} </color>");
                if (enemy != null && _hit.collider.name == "HeadCollider")
                    enemy.TakeDamage(_damage * _headDamageRate);
                if (enemy != null && _hit.collider.name != "HeadCollider")
                    enemy.TakeDamage(_damage);
            }

        }
        _ammoInMagazine--;
    }

    public void Take()
    {
        IsActive = true;
        Mesh.SetActive(true);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _allowShooting == true && _ammoInMagazine > 0)
            Shot();
        if (Input.GetKeyDown(KeyCode.R) || (_ammoInMagazine <= 0 && _ammoInInventory > 0))
            Reload();
    }
    private Vector3 GetShootDirection()
    {
        var firePoint = _firePointStartTransform;
        firePoint.localRotation = Quaternion.identity;
        firePoint.localRotation = Quaternion.Euler(_firePointStartTransform.localRotation.x + Random.Range(_minFireDispersion, _maxFireDispersion),
            _firePointStartTransform.localRotation.y + Random.Range(_minFireDispersion, _maxFireDispersion), _firePointStartTransform.localRotation.z +
            Random.Range(_minFireDispersion, _maxFireDispersion));
        Vector3 direction = firePoint.TransformDirection(Vector3.forward);
        return direction;  
    }
    private void AllowShooting()
    {
        _allowShooting = !_allowShooting;
        
    }
}
