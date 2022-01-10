using UnityEngine.AI;
using UnityEngine;

public class Ghoul : MonoBehaviour, IEnemy
{
    private int _health = 100;
    private NavMeshAgent NavMeshAgent;
    private PlayerController _target;

    private void Awake()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        NavMeshAgent.SetDestination(_target.transform.localPosition);
    }
    public void Attack()
    {
      
    }

    public void Move()
    {
        
    }

    public void TakeDamage()
    {
       
    }
    public void SetTarget(PlayerController player)
    {
        _target = player;
    }
}
