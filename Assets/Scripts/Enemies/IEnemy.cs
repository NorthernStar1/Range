

public interface IEnemy
{
    public abstract void Attack();
    public abstract void Move();
    public abstract void TakeDamage();

    public abstract void SetTarget(PlayerController player);
}
