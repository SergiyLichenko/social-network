using System.Collections.Generic;

namespace SocialNetwork.Graph.Models
{
    public class Graph
    {
        public IEnumerable<Node> Nodes { get; set; }
        public IEnumerable<Edge> Edges { get; set; }
    }
}