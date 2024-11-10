using Entity.Enemy.Behaviour_tree;
using UnityEngine;

namespace Entity.Enemy
{
    [RequireComponent(typeof(AttackManager), typeof(SearchManager), typeof(IdleManager))]
    [RequireComponent(typeof(PatrolManager))]
    public class BehaviourTreeManager : MonoBehaviour
    {
        private SequenceNode _root;
        private Enemy _enemy;
        [SerializeField] private AttackManager attackManager;
        [SerializeField] private SearchManager searchManager;
        [SerializeField] private IdleManager idleManager;
        [SerializeField] private PatrolManager patrolManager;
        
        public void Execute()
        {
            _root.Execute();
        }

        public void Init(Enemy enemy)
        {
            _enemy = enemy;
            _root = new SequenceNode();
            var idleNode = new ActionNode(() => idleManager.IsIdle);
            var attackNode = new ActionNode(() => attackManager.Attack());
            var searchNode = new ActionNode(() => searchManager.Search());
            var patrolNode = new ActionNode(() => patrolManager.Patrol());
            
            var patrolAndSearchNode = new ParallelNode(ParallelCompletionCondition.Any);
            patrolAndSearchNode.AddChild(patrolNode);
            patrolAndSearchNode.AddChild(searchNode);
            
            var searchAndAttackSequence = new SequenceNode();
            searchAndAttackSequence.AddChild(searchNode);
            searchAndAttackSequence.AddChild(attackNode);
            
            _root.AddChild(patrolAndSearchNode);     // Перший етап: патрулювання і пошук
            _root.AddChild(searchAndAttackSequence); // Другий етап: пошук -> атака
            _root.AddChild(idleNode);                // Режим простою, якщо атака не виконувалась
            
            
            patrolManager.Init();
            attackManager.Init(_enemy);
        }
    }
}