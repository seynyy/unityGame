using System;

namespace Entity.Enemy.Behaviour_tree
{
    public class ActionNode : Node
    {
        private readonly Func<bool> action;

        public ActionNode(Func<bool> action)
        {
            this.action = action;
        }
    
        public override bool Execute()
        {
            return action();
        }
    }
}