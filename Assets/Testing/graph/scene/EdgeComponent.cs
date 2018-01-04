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
            Color positiveColor = new Color(0, 255, 0);
            Color negativeColor = new Color(255, 0, 0);

            double factor = (Math.Abs(score) * 1.0) / 50;

            if (score > 0)
            {
                return new Color((int)(positiveColor.r * factor), (int)(positiveColor.g * factor), (int)(positiveColor.b * factor));
            }
            else
            {
                return new Color((int)(negativeColor.r * factor), (int)(negativeColor.g * factor), (int)(negativeColor.b * factor));
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

