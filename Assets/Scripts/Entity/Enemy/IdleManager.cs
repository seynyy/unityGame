using System.Collections;
using UnityEngine;

namespace Entity.Enemy
{
    [RequireComponent(typeof(AnimationManager))]
    public class IdleManager : MonoBehaviour
    {
        [SerializeField] private AnimationManager animationManager;
        public bool IsIdle {get; private set;}
        
        public IEnumerator Idle(float duration)
        {
            animationManager.SetIdle();
            IsIdle = true;
            yield return new WaitForSeconds(duration);
            IsIdle = false;
        }
    }
}