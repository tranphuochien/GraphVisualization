using System;

namespace AssemblyCSharp
{
	public class MultiEdgesForSingleNodeGraphGenerator : AbstractGraphGenerator
	{

		public override void GenerateGraph (Graph graph)
		{
            SimpleGraphNode tmp = new SimpleGraphNode(null, 0);
			AbstractGraphNode firstNode =  graph.NewNode(tmp);
			AbstractGraphNode secondNode = graph.NewNode (tmp);
			AbstractGraphNode thirdNode = graph.NewNode (tmp);

			graph.NewEdge (firstNode, secondNode);
			graph.NewEdge (secondNode, firstNode);
			graph.NewEdge (firstNode, secondNode);
			graph.NewEdge (firstNode, secondNode);
			graph.NewEdge (firstNode, secondNode);
			graph.NewEdge (firstNode, secondNode);
			graph.NewEdge (firstNode, secondNode);

			graph.NewEdge (secondNode, thirdNode);
		}
	}
}

