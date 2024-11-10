using System.Collections.Generic;

namespace Entity.Enemy.Behaviour_tree
{
    public class ParallelNode : Node
    {
        private readonly List<Node> _children = new List<Node>();
        private readonly ParallelCompletionCondition _completionCondition;

        public ParallelNode(ParallelCompletionCondition completionCondition)
        {
            _completionCondition = completionCondition;
        }
    
        public void AddChild(Node child)
        {
            _children.Add(child);
        }

        public override bool Execute()
        {
            bool allSucceed = true;
            foreach (var child in _children)
            {
                bool result = child.Execute();
                if(_completionCondition == ParallelCompletionCondition.Any && result)
                    return true;
            
                if (!result)
                    allSucceed = false;
            }
    
            return _completionCondition == ParallelCompletionCondition.All && allSucceed;
        }
    }
}