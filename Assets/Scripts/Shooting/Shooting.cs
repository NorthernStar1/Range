using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public Rigidbody Bullet;
    public GameObject BulletSpawnPoint;
    public float ShootSpeed = 900f;
    private int AmmoInMagazine;
    public int AmmoInInvenory = 36;
    private int AmmoDiference;
    public int MaxAmmoInMagazine = 12;

    public AudioSource AudioSource;
    public AudioClip FireAudio;
    public AudioClip ReloadAudio;
    //public Animator Animator;
    //public bool AllowShoting;

    public Text AmmoCountText;

    public ParticleSystem ShootFlash;
    public Camera PlayerCamera;
    public float ShootingRange = 50f;
    private RaycastHit _hit;

    public float Force = 155f;




    private void Awake()
    {    
        //AllowShoting = true;
        AmmoInMagazine = MaxAmmoInMagazine;
        AmmoCountText.text = AmmoInMagazine.ToString() + "/" + AmmoInInvenory.ToString();
    }
    private void Update()
    {
        if (PausedMenu._IsPaused == true)
            return;
        else
        {
            if (Input.GetMouseButtonDown(0) && AmmoInMagazine > 0)
            Shoot();

            if ((Input.GetKeyDown(KeyCode.R) || AmmoInMagazine <= 0)  && AmmoInInvenory > 0)
            {
                Reload();
            }
        }
        
    }

    private void TestShoot()
    {
        { 
            //Animator.Play("TestWeaponShoting");
            //Animator.SetTrigger("Shot");
            //AllowShoting = false;    
        }
    }
    private void StartReload()
    {
        //AllowShoting = false;
        //AudioSource.PlayOneShot(ReloadAudio);
        //Animator.SetTrigger("Reload");

    }
    private void EndReload()
    { 
        //AllowShoting = true;
    }
    public void EnabledAllowShoting()
    {
        //AllowShoting = true;
    }

    private void Shoot()
    {
        AudioSource.PlayOneShot(FireAudio);
        ShootFlash.Play();
        AmmoInMagazine--;
        AmmoCountText.text = AmmoInMagazine.ToString() + "/" + AmmoInInvenory.ToString();

        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out _hit, ShootingRange))
        {
            if (_hit.rigidbody != null)
                _hit.rigidbody.AddForce(-_hit.normal * Force);
        }
    }
    private void Reload()
    {
        AudioSource.PlayOneShot(ReloadAudio);

        AmmoDiference = MaxAmmoInMagazine - AmmoInMagazine;
        if (AmmoDiference > AmmoInInvenory)
            AmmoDiference = AmmoInInvenory;

        AmmoInInvenory -= AmmoDiference;
        AmmoInMagazine += AmmoDiference;

    }
}
