using UnityEngine;
using UnityEngine.AI;

namespace Entity.Enemy
{
    public class MovementManager : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent navMeshAgent;
        [SerializeField] private AnimationManager animationManager;

        private void Awake()
        {
            navMeshAgent.updateRotation = false;
            navMeshAgent.updateUpAxis = false;
        }

        public void MoveTo(Vector3 destination)
        {
            animationManager.SetRunning();
            navMeshAgent.SetDestination(destination);
        }

        public bool IsAtDestination()
        {
            return !navMeshAgent.pathPending && 
                   navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance;
        }
    }
}