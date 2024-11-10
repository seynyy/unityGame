using System.Collections.Generic;
using UnityEngine;

namespace Entity.Enemy
{
    internal class PatrolManager : MonoBehaviour
    {
        private List<Vector2> _patrolPoints;
        private int _currentPatrolIndex;
        [SerializeField] private MovementManager movementManager;
        private bool _isPatrolComplete;

        public void Init()
        {
            _patrolPoints = GeneratePatrolPoints(10);
            _currentPatrolIndex = 0;
            _isPatrolComplete = false;
            
            MoveToNextPatrolPoint();
        }

        public bool Patrol()
        {
            if (_isPatrolComplete)
                return true;
            
            if (!movementManager.IsAtDestination())
                return false;

            _currentPatrolIndex++;

            if (_currentPatrolIndex >= _patrolPoints.Count)
            {
                _isPatrolComplete = true;
                return true;
            }

            MoveToNextPatrolPoint();
            return false;
        }

        private void MoveToNextPatrolPoint()
        {
            if (_patrolPoints.Count == 0) return;
            
            Vector2 targetPoint = _patrolPoints[_currentPatrolIndex];
            movementManager.MoveTo(new Vector3(targetPoint.x, transform.position.y, targetPoint.y));
        }

        private List<Vector2> GeneratePatrolPoints(int numberOfPoints)
        {
            var patrolPoints = new List<Vector2>();
            for (int i = 0; i < numberOfPoints; i++)
            {
                var randomPoint = Random.insideUnitCircle * 5 +
                                  new Vector2(transform.position.x, transform.position.y);
                patrolPoints.Add(randomPoint);
            }
            return patrolPoints;
        }
    }
}