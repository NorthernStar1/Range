

using UnityEngine;

public class Pistol : MonoBehaviour, IWeapon
{
    private int _damage = 50;
    private float _range = 20f;
    public float _fireRate = 1; // 1 per 1sec 60shots per 1 minute
    private int _magazineSize = 15;
    private int _ammoInMagazine;
    private int _ammoInInventory = 45;
    public Camera PlayerCamera;
    private RaycastHit _hit;

    public AudioSource AudioSource;
    public AudioClip ShootAudio;
    public AudioClip ReloadAudio;
    public ParticleSystem ShootEffect;

    public bool IsActive;
    public GameObject Mesh;



    public void Initialize()
    {
        _ammoInMagazine = _magazineSize;
        Remove();
        PlayerCamera = PlayerController.Singleton.Camera;

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
            if (_hit.rigidbody != null)
                _hit.rigidbody.AddForce(-_hit.normal * _damage);
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
