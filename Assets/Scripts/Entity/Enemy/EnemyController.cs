using System;
using UnityEngine;

namespace Entity.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private BehaviourTreeManager behaviourTreeManager;
        
        private Enemy _enemy;
        
        private void Awake()
        {
            _enemy = new Enemy("Slime<3", 10, 10, 10, 4);

            behaviourTreeManager.Init(_enemy);
        }

        private void Update()
        {
            behaviourTreeManager.Execute();
        }
    }
}