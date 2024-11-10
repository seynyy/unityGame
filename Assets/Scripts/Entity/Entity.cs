using System;

namespace Entity
{
    public class Entity
    {
        public string Name { get; private set; }
        public int BaseHp { get; private set; }
        public int BaseDmg { get; private set; }
        public float BaseMoveSpeed { get; private set; }
        public float AttackCooldown { get; private set; }
        public int CurrentHp { get; private set; }


        protected Entity(string name, int baseHp, int baseDmg, float baseMoveSpeed, float attackCooldown)
        {
            Name = name;
            BaseHp = baseHp;
            CurrentHp = baseHp;
            BaseDmg = baseDmg;
            BaseMoveSpeed = baseMoveSpeed;
            AttackCooldown = attackCooldown;
        }

        public void TakeDamage(int damage)
        {
            int hp = Math.Max(CurrentHp -= damage, 0);

            if (hp == 0)
                Console.WriteLine("Entity died");
            CurrentHp = hp;
            
        }
    }
}