using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssemblyCSharp
{
    class DCGraphNode : AbstractGraphNode
    {
        private DCGraphBackend graphBackend;
        private DCProfile mData;

        public DCGraphNode(DCGraphBackend dcGraphBackend,
            DCProfile profile)
        {
            this.graphBackend = dcGraphBackend;
            this.mData = profile;
        }


        public override void Accept(GraphEdgeVisitor graphEdgeVisitor)
        {
            graphBackend.FindEdges(mData.Id).ForEach(edge => {
                graphEdgeVisitor(edge);
            });
        }

        public override long GetDegree()
        {
            return graphBackend.FindEdges(mData.Id).Count;
        }

        public override bool IsAdjacent(AbstractGraphNode graphNode)
        {
            return graphBackend.FindEdges(mData.Id, graphNode.GetId()).Count > 0;
        }

        public override long GetId()
        {
            return mData.Id;
        }

        public override string GetUrl()
        {
            return mData.ImgUrl;
        }
    }
}
