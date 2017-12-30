using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssemblyCSharp
{
    class DCGraphNode : AbstractGraphNode
    {
        private DCGraphBackend graphBackend;
        private long mId;
        private string mAlias;
        private string mRealName;
        private string mCity;
        private string mAlignment;
        private string mOccupation;
        private string mFacebook;
        private string mImgUrl;

        public DCGraphNode(DCGraphBackend dcGraphBackend,
            long id,
            string alias,
            string realName,
            string city,
            string alignment,
            string occupation,
            string facebook,
             string imgUrl)
        {
            this.graphBackend = dcGraphBackend;
            this.mId = id;
            this.mAlias = alias;
            this.mRealName = realName;
            this.mCity = city;
            this.mAlignment = alignment;
            this.mOccupation = occupation;
            this.mFacebook = facebook;
            this.mImgUrl = imgUrl;
        }


        public override void Accept(GraphEdgeVisitor graphEdgeVisitor)
        {
            graphBackend.FindEdges(mId).ForEach(edge => {
                graphEdgeVisitor(edge);
            });
        }

        public override long GetDegree()
        {
            return graphBackend.FindEdges(mId).Count;
        }

        public override bool IsAdjacent(AbstractGraphNode graphNode)
        {
            return graphBackend.FindEdges(mId, graphNode.GetId()).Count > 0;
        }

        public override long GetId()
        {
            return mId;
        }
    }
}
