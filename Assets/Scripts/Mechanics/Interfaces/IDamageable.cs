public interface IDamageable : IHitable {
    void TakeDamage(int teamId, int damageAmount);
}