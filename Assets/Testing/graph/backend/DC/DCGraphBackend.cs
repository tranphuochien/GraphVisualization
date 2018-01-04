using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssemblyCSharp
{
    class DCGraphBackend : AbstractGraphBackend
    {
        private List<AbstractGraphNode> AllGraphNodes = new List<AbstractGraphNode>();
        private List<AbstractGraphEdge> AllGraphEdges = new List<AbstractGraphEdge>();

        public override AbstractGraphNode NewNode(AbstractModel data)
        {
            if (data is DCProfile)
            {
                DCGraphNode newNode = new DCGraphNode(this, (DCProfile)data);
                AllGraphNodes.Add(newNode);
                NotifyBackendNodeCreated(newNode);
                return newNode;
            }
            return null;
        }

        public override AbstractGraphEdge NewEdge(AbstractGraphNode from, AbstractGraphNode to)
        {
            DCGraphEdge newEdge = new DCGraphEdge(AllGraphEdges.Count, from, to);
            AllGraphEdges.Add(newEdge);
            NotifyBackendEdgeCreated(newEdge);
            return newEdge;
        }

        public override AbstractGraphEdge NewEdge(AbstractGraphNode from, AbstractGraphNode to, int score)
        {
            DCGraphEdge newEdge = new DCGraphEdge(AllGraphEdges.Count, from, to, score);
            AllGraphEdges.Add(newEdge);
            NotifyBackendEdgeCreated(newEdge);
            return newEdge;
        }
        
        public override AbstractGraphNode GetNodeById(long nodeId)
        {
            return AllGraphNodes.Find(node => {
                return node.GetId() == nodeId;
            });
        }

        public List<AbstractGraphEdge> FindEdges(long nodeId)
        {
            return AllGraphEdges.FindAll(edge => {
                AbstractGraphNode startNode = edge.GetStartGraphNode();
                AbstractGraphNode endNode = edge.GetEndGraphNode();
                return startNode.GetId() == nodeId || endNode.GetId() == nodeId;
            });
        }

        public List<AbstractGraphEdge> FindEdges(long startOrEndNodeId, long endOrStartNodeId)
        {
            return AllGraphEdges.FindAll(edge => {
                AbstractGraphNode startNode = edge.GetStartGraphNode();
                AbstractGraphNode endNode = edge.GetEndGraphNode();

                return (startNode.GetId() == startOrEndNodeId && endNode.GetId() == endOrStartNodeId)
                    || (startNode.GetId() == endOrStartNodeId && endNode.GetId() == startOrEndNodeId);
            });
        }

        public override long CountAllEdges()
        {
            return AllGraphEdges.Count;
        }

        public override long CountAllNodes()
        {
            return AllGraphNodes.Count;
        }
    }
}
