using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class EdgeComponent : AbstractSceneComponent
	{
		public bool MultiEdge = false;
		private AbstractGraphEdge graphEdge;

		public EdgeComponent (AbstractGraphEdge graphEdge, GameObject visualComponent) : base(visualComponent)
		{
			this.graphEdge = graphEdge;
			InitializeEdgeComponent ();
		}

		private void InitializeEdgeComponent()
		{
			LineRenderer line = GetVisualComponent ().GetComponent<LineRenderer> ();
			line.name = "Edge_" + graphEdge.GetId ();
            line.startColor = line.endColor = GetColorByRelationshipScore(graphEdge.GetScoreRelationship());
        
            float angle = UnityEngine.Random.Range (0, 360);
		
			float xRotation = Mathf.Cos (Mathf.Deg2Rad * angle) * 100;
			float yRotation = Mathf.Sin (Mathf.Deg2Rad * angle) * 100;
			float zRotation = Mathf.Cos (Mathf.Deg2Rad * angle) * 100;
			GetVisualComponent().transform.Rotate(new Vector3 (xRotation, yRotation, zRotation));
		}

        private Color GetColorByRelationshipScore(int score)
        {
            Color positiveColor = new Color(0.29f, 0.78f, 0.31f);
            Color negativeColor = new Color(0.78f, 0.22f, 0.21f);

            double factor = (Math.Abs(score) * 1.0) / 50;

            if (score > 0)
            {
                float temp = (float) (positiveColor.g * factor);
                if (temp > 1.0f)
                {
                    temp = 1.0f;
                } else if (temp < 0.58f)
                {
                    temp = 0.58f;
                }
                Color temp1 = new Color((positiveColor.r), temp, (positiveColor.b));
                return temp1;
            }
            else
            {
                float temp = (float)(negativeColor.r * factor);
                if (temp > 1.0f)
                {
                    temp = 1.0f;
                }
                else if (temp < 0.58f)
                {
                    temp = 0.58f;
                }
                Color temp1 = new Color(temp, (int)(negativeColor.g), (int)(negativeColor.b));
                return temp1;
            }
        }

		public AbstractGraphEdge GetGraphEdge()
		{
			return graphEdge;
		}

		public void UpdateGeometry(Vector3 start, Vector3 end)
		{
			LineRenderer line = GetVisualComponent ().GetComponent<LineRenderer> ();
			line.SetPosition (0, start);
			line.SetPosition (1, end);
		}

	}
}

