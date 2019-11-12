import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { User } from 'src/app/models/user.model';

@Component({
    selector: 'app-user',
    templateUrl: './user.component.html',
    styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
    public user: User;

    constructor(private route: ActivatedRoute) {
    }

    ngOnInit(): void {
        this.route.data.subscribe(x => {
            this.user = x["user"] as User;
        });
    }
}
