

public interface IEnemy
{
    void Attack();
    void Move();
    void TakeDamage(float amount);

    void SetTarget(PlayerController player);
}
