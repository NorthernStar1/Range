using UnityEngine.AI;
using UnityEngine;
using System.Collections;

public class Ghoul : MonoBehaviour, IEnemy
{
    public float Distance;
    private float _triggerRange = 10f;
    private float _attackRange = 2f;
    private bool _isDying = false;

    public GameObject DeathEffect;


    public float _health = 100f;
    private NavMeshAgent NavMeshAgent;
    public PlayerController _target;
    private Animation _animation;

    private void Awake()
    {
        _animation = GetComponent<Animation>();
        NavMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        GetDistance();   
    }
    public void Attack()
    {
        
        Debug.Log("Attack");
        _animation.Play("Attack1");
    }

    public void Move()
    {
        if (_isDying == true)
            return;
        if (Distance <= _attackRange)
        {
            Attack();
        }
        if (Distance > _triggerRange)
        {
            Debug.Log("Idle");
            _animation.Play("Idle");
        }

        if (Distance <= _triggerRange && Distance > _attackRange)
        {
            Run();
        }
       
    }

    public void TakeDamage(float amount)
    {
        _health -= amount;
        if(_health <= 0f)
        {
            _isDying = true;
            StartCoroutine(Die());
        }
        Debug.Log($"Ghoul Take Damage! Heath is {_health}");
    }
    public void SetTarget(PlayerController player)
    {
        _target = player;
    }
    private void GetDistance()
    {
        if (_target != null)
        {
            Distance = Vector3.Distance(_target.transform.position, transform.position);
            Move();
        }
    }
    private void Run()
    {
        Debug.Log("Run");
        NavMeshAgent.speed = 7f;
        _animation.Play("Run");
        NavMeshAgent.SetDestination(_target.transform.position);
    }
    private IEnumerator Die()
    {
        
        _animation.Play("Death");
        yield return new WaitForSeconds(0.5f);
        Instantiate(DeathEffect, transform);
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }


}
