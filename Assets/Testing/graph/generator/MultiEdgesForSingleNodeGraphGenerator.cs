using System;

namespace AssemblyCSharp
{
    public class MultiEdgesForSingleNodeGraphGenerator : AbstractGraphGenerator
    {

        public override void GenerateGraph(Graph graph)
        {
            //AbstractGraphNode firstNode =  graph.NewNode();
            //AbstractGraphNode secondNode = graph.NewNode ();
            //AbstractGraphNode thirdNode = graph.NewNode ();
            DCProfile tmp1 = new DCProfile(0, "Superman", "Kal - El", "Metropolis", "Hero", "Reporter", "https://www.facebook.com/superman", "http://www.dccomics.com/sites/default/files/styles/character_thumb_160x160/public/CharThumb_Rebirth_Superman_586ee06eddc447.49308496.jpg?itok=VvQpy2_u");
            DCProfile tmp2 = new DCProfile(1, "Batman", "Bruce Wayne", "Gotham", "Hero", "CEO of Wayne Enterprises", "https://www.facebook.com/batman", "http://www.dccomics.com/sites/default/files/styles/character_thumb_160x160/public/CharThumb_Rebirth_Batman_586ee0e2dec3a9.16022233.jpg?itok=keF21kcJ");
            DCProfile tmp3 = new DCProfile(2, "Krypto", "Krypto", "Metropolis", "Hero", "Family pet", "Unknown", "http://www.dccomics.com/sites/default/files/styles/character_thumb_160x160/public/CharThumb_215x215_krypto_52abac7b059a84.83507397.jpg?itok=N0P3xP5z");
            AbstractGraphNode firstNode = graph.NewNode(Constant.DC_MODEL, tmp1);
            AbstractGraphNode secondNode = graph.NewNode(Constant.DC_MODEL, tmp2);
            AbstractGraphNode thirdNode = graph.NewNode(Constant.DC_MODEL, tmp3);

            graph.NewEdge(firstNode, secondNode);
            graph.NewEdge(secondNode, firstNode);
            graph.NewEdge(secondNode, thirdNode);
        }
    }
}

