using Entity.Player;
using UnityEngine;

namespace Entity.Enemy
{
    [RequireComponent(typeof(MovementManager), typeof(AnimationManager))]
    public class AttackManager : MonoBehaviour
    {
        [SerializeField] private MovementManager movementManager;
        [SerializeField] private AnimationManager animationManager;
        [SerializeField] private PlayerController player;

        private const float AttackRange = 2f;
        private float _attackCooldown;
        private float _lastAttackTime;

        public void Init(Enemy enemy)
        {
            _attackCooldown = enemy.AttackCooldown;
            _lastAttackTime = -_attackCooldown;
        }

        public bool Attack()
        {
            if (!player) return false;

            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distanceToPlayer <= AttackRange)
            {
                if (!(Time.time >= _lastAttackTime + _attackCooldown)) return false;
                PerformAttack();
                _lastAttackTime = Time.time;
                return true;
            }
            movementManager.MoveTo(player.transform.position);

            return false;
        }

        private void PerformAttack()
        {
            animationManager.SetAttack();
            Debug.Log($"Aтакує гравця!");
        }

        public void Init()
        {
            
        }
    }
}