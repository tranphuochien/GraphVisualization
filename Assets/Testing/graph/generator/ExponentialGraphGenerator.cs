using System;

namespace AssemblyCSharp
{
	public class ExponentialGraphGenerator : AbstractGraphGenerator
	{
		private const int MAX_LEVEL = 3;
        SimpleGraphNode tmp = new SimpleGraphNode(null, 0);

        public override void GenerateGraph (Graph graph)
		{
			AbstractGraphNode root = graph.NewNode (tmp);
			GenerateDescedants (1, graph, root);
		}

		void GenerateDescedants (int level, Graph graph, AbstractGraphNode startNode)
		{
			if (level > MAX_LEVEL) {
				return;
			}
			for (int index = 0; index < Math.Exp(level); index++) {
				AbstractGraphNode descedantNode = graph.NewNode (tmp);
				graph.NewEdge (startNode, descedantNode);

				GenerateDescedants (level + 1, graph, descedantNode);
			}
		}
	}
}

