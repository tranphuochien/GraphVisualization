using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssemblyCSharp
{
    class DCGraphEdge : AbstractGraphEdge
    {
        private long id;
        private int score = 0;
        private AbstractGraphNode startNode;
        private AbstractGraphNode endNode;

        public DCGraphEdge(long id, AbstractGraphNode startNode, AbstractGraphNode endNode)
        {
            this.id = id;
            this.startNode = startNode;
            this.endNode = endNode;
        }

        public override AbstractGraphNode GetStartGraphNode()
        {
            return startNode;
        }

        public override AbstractGraphNode GetEndGraphNode()
        {
            return endNode;
        }

        public override long GetId()
        {
            return id;
        }

        public override int GetScoreRelationship()
        {
            return score;
        }
    }
}
