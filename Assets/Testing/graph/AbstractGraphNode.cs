﻿using System;

namespace AssemblyCSharp
{
	public delegate void GraphEdgeVisitor(AbstractGraphEdge edge);

	public abstract class AbstractGraphNode : AbstractGraphElement
	{
		public abstract void Accept(GraphEdgeVisitor graphEdgeVisitor);

		public abstract long GetDegree();

		public abstract bool IsAdjacent(AbstractGraphNode graphNode);
	}
}

