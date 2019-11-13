import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
import { User } from 'src/app/models/user.model';

@Component({
    selector: 'app-details',
    templateUrl: './details.component.html',
    styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
    public columns: string[];

    constructor(private route: ActivatedRoute,
        private userService: UserService) { }

    ngOnInit(): void {
        this.columns = Object.getOwnPropertyNames(User.getDefaultUser());
        this.route.queryParams.subscribe(x => {
            let ids = x["ids"] as number[];
            if (!ids) { return; }

            this.userService.getAll(ids, this.columns).subscribe((x) => {
                console.log(x);
            });
        });
    }

}
