namespace Entity.Enemy
{
    public class Enemy : Entity
    {
        public Enemy(string name, int baseHp, int baseDmg, float baseMoveSpeed, float attackCooldown) : base(name, baseHp, baseDmg, baseMoveSpeed, attackCooldown)
        {
        }
    }
}