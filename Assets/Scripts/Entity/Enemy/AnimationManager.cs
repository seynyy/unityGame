using UnityEngine;

namespace Entity.Enemy
{
    public class AnimationManager : MonoBehaviour
    {
        private static readonly int IsRunning = Animator.StringToHash("isRunning");
        [SerializeField] private Animator animator;
        
        public void SetIdle() => animator.SetBool(IsRunning, false);
        public void SetRunning() => animator.SetBool(IsRunning, true);
        public void SetAttack() => animator.SetBool(IsRunning, true);
    }
}