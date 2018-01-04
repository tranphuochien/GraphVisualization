using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class Graph : GraphBackendListener
	{
		public delegate void NodeVisitor (AbstractGraphNode node);

		private AbstractGraphBackend graphBackend;
		private List<AbstractGraphNode> loadedNodes = new List<AbstractGraphNode> ();
		private GraphListeners listeners = new GraphListeners();

		public Graph (AbstractGraphBackend graphBackend)
		{
			this.graphBackend = graphBackend;
			this.graphBackend.AddListener (this);
		}


		public AbstractGraphNode NewNode(String className, AbstractModel data) 
		{
            switch (className)
            {
                case "dcmodel":
                    return (DCGraphNode) graphBackend.NewNode(data);
                case "simplemodel":
                    return graphBackend.NewNode(null);
                default:
                    return graphBackend.NewNode(null);
            }
		}

        public AbstractGraphNode NewNode()
        {
            return this.NewNode(Constant.SIMPLE_MODEL, null);
        }

        public AbstractGraphEdge NewEdge(AbstractGraphNode from, AbstractGraphNode to)
        {
            return graphBackend.NewEdge(from, to);
        }

        public AbstractGraphEdge NewEdge(AbstractGraphNode from, AbstractGraphNode to, int score)
		{
			return graphBackend.NewEdge (from, to, score);
		}

		public void AddGraphListener(GraphListener graphListener)
		{
			listeners.AddGraphListener(graphListener);
		}

		public void GraphBackendNodeCreated(AbstractGraphNode graphNode)
		{
			loadedNodes.Add (graphNode);
			listeners.NotifyNodeCreated (graphNode);
		}

		public void GraphBackendEdgeCreated(AbstractGraphEdge graphEdge)
		{
			listeners.NotifyEdgeCreated (graphEdge);
		}

		public void Accept(NodeVisitor visitor)
		{
			loadedNodes.ForEach (loadedNode => {
				visitor(loadedNode);
			});
		}
	}
}

