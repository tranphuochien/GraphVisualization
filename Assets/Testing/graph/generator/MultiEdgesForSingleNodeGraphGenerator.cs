using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AssemblyCSharp
{
    public class MultiEdgesForSingleNodeGraphGenerator : AbstractGraphGenerator
    {

        public override void GenerateGraph(Graph graph)
        {
            //AbstractGraphNode firstNode =  graph.NewNode();
            //AbstractGraphNode secondNode = graph.NewNode ();
            //AbstractGraphNode thirdNode = graph.NewNode ();

            List<DCProfile> listCharacter = new List<DCProfile>();
            List<AbstractGraphNode> listNode = new List<AbstractGraphNode>();
            using (var reader = new StreamReader(@"DCs.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    DCProfile myCharacter = new DCProfile(Int32.Parse(values[0]) - 1, values[1], values[2], values[3], values[4], values[5], values[6], values[7]);
                    listCharacter.Add(myCharacter);
                }

                reader.Close();
            }

            int[][] Relationships = File.ReadAllLines(@"Relationships.csv")
                   .Select(l => l.Split(',').Select(i => int.Parse(i)).ToArray())
                   .ToArray();

            foreach (DCProfile profile in listCharacter)
            {
                listNode.Add(graph.NewNode(Constant.DC_MODEL, profile));
            }

            int rowNum = Relationships.Length;
            int colNum = 0;
            if (rowNum != 0)
            {
                colNum = Relationships[0].Length;
            }

            for (int i = 0; i < rowNum; i++)
            {
                for (int j = 0; j < colNum; j++)
                {
                    if (Relationships[i][j] != 0)
                    {
                        graph.NewEdge(listNode[i], listNode[j], Relationships[i][j]);
                    }
                }
            }
        }
    }
}

