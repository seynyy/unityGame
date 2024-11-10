namespace Entity.Player
{
    public class Player : Entity
    {
        public Player(string name, int baseHp, int baseDmg, float baseMoveSpeed, float attackCooldown) : base(name, baseHp, baseDmg, baseMoveSpeed, attackCooldown)
        {
        }
    }
}