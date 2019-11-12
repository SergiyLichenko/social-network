import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { Node, Edge } from '@swimlane/ngx-graph';
import { Graph } from 'src/app/models/graph.model';

@Component({
    selector: 'app-user',
    templateUrl: './user.component.html',
    styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
    public user: User;
    public nodes: Node[];
    public edges: Edge[];

    constructor(private route: ActivatedRoute) {
    }

    ngOnInit(): void {
        this.route.data.subscribe(x => {
            this.user = x["user"] as User;
            this.nodes = this.getNodes(this.user.graph);
            this.edges = this.getEdges(this.user.graph);
        });
    }

    private getNodes(graph: Graph) {
        let nodes: Node[] = [];
        if (!graph || !graph.nodes) {
            return nodes;
        }

        for (let item of graph.nodes) {
            nodes.push({
                label: item.value,
                id: item.id.toString()
            })
        }

        return nodes;
    }

    private getEdges(graph: Graph) {
        let edges: Edge[] = [];
        if (!graph || !graph.edges) {
            return edges;
        }

        for (let item of graph.edges) {
            edges.push({
                source: item.fromId.toString(),
                target: item.toId.toString(),
                label: item.label
            });
        }

        return edges;
    }
}
