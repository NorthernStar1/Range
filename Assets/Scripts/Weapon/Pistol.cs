using UnityEngine;

public class Pistol : MonoBehaviour, IWeapon
{
    private float _damage = 20f;
    private float _range = 20f;
    private int _magazineSize = 15;
    private int _ammoInMagazine;
    private int _ammoInInventory = 45;
    private Camera PlayerCamera;
    private RaycastHit _hit;
    private float _headDamageRate = 2f;

    public AudioSource AudioSource;
    public AudioClip ShootAudio;
    public AudioClip ReloadAudio;
    public ParticleSystem ShootEffect;

    public bool IsActive;
    public GameObject Mesh;



    public void Initialize()
    {
        _ammoInMagazine = _magazineSize;
        //PlayerCamera = PlayerController.Singleton.Camera;

    }
    public void Shot()
    {
        if (IsActive == false)
            return;

        AudioSource.PlayOneShot(ShootAudio);
        ShootEffect.Play();
        _ammoInMagazine--;
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out _hit, _range))
        {
            IEnemy enemy = _hit.transform.GetComponentInParent<IEnemy>();
            Debug.Log($"enemy is <color=yellow> {enemy} </color> ->   Hit to <color=yellow> {_hit.collider.name} </color>");
            if( enemy != null && _hit.collider.name == "HeadCollider")
            enemy.TakeDamage(_damage * _headDamageRate);
            if (enemy != null && _hit.collider.name != "HeadCollider")
                enemy.TakeDamage(_damage);
        }
    }

    public void Reload()
    {
        if (IsActive == false)
            return;

        AudioSource.PlayOneShot(ReloadAudio);
        var ammoDiference = _magazineSize - _ammoInMagazine;
        if (ammoDiference > _ammoInInventory)
            ammoDiference = _ammoInInventory;
        _ammoInInventory -= ammoDiference;
        _ammoInMagazine += ammoDiference;
    }

    public void Update()
    {
        if (IsActive == false)
            return;

        if(Input.GetMouseButtonDown(0) && _ammoInMagazine > 0)
        {
            Shot();
        }
        if ((Input.GetKeyDown(KeyCode.R) || _ammoInMagazine <= 0) && _ammoInInventory > 0)
        {
            Reload();
        }
    }

    public void Take()
    {
        IsActive = true;
        Mesh.SetActive(true);

    }

    public void Remove()
    {
        IsActive = false;
        Mesh.SetActive(false);
    }

    
}
