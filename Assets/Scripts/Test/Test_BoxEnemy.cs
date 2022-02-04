using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_BoxEnemy : MonoBehaviour, IEnemy
{
    public PlayerController Player;
    public float Health = 100f;
    public void Attack()
    {
        Debug.Log("Box Attack!");
    }

    public void Move()
    {
        Debug.Log("Box Move!");
    }

    public void SetTarget(PlayerController player)
    {
        Player = player;
    }

    public void TakeDamage(float amount)
    {
        
        Health -= amount;
        if (Health <= 0f)
           StartCoroutine(Die());
        Debug.Log($"Box Take Damage! Heath is {Health}");
    }
    public IEnumerator Die()
    {
        transform.localScale += new Vector3(5f, 5f, 5f);
        yield return new WaitForSeconds(2f);
        transform.localScale -= new Vector3(5f, 5f, 5f);
        yield return new WaitForSeconds(2f);
        transform.position += new Vector3(0, 5f, 0);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
