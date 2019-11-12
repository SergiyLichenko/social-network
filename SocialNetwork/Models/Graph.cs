using System.Collections.Generic;

namespace SocialNetwork.Models
{
    public class Graph
    {
        public IEnumerable<Node> Nodes { get; set; }
        public IEnumerable<Edge> Edges { get; set; }
    }
}