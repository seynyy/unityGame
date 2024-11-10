using System.Collections.Generic;

namespace Entity.Enemy.Behaviour_tree
{
    public class SequenceNode : Node
    {
        private readonly List<Node> _children = new List<Node>();
    
        public void AddChild(Node child)
        {
            _children.Add(child);
        }
    
        public override bool Execute()
        {
            foreach (var child in _children)
            {
                if (!child.Execute())
                    return false;
            }

            return true;
        }
    }
}