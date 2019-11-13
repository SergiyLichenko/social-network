import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
import { User } from 'src/app/models/user.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { FormControl } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';

const ColumnMap = {
    "id": "ID",
    "firstName": "First Name",
    "lastName": "Last Name",
    "email": "Email",
    "userName": "User Name",
    "country": "Country",
    "city": "City",
    "gender": "Gender"
};

const InitialColumns = ["id", "firstName", "lastName", "userName", "gender"];
const AllColumns = ["id", "firstName", "lastName", "email", "userName", "country", "city", "gender"];

@Component({
    selector: 'app-details',
    templateUrl: './details.component.html',
    styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
    public columns = [];
    public displayColumns = [];
    public dataSource: MatTableDataSource<User> = new MatTableDataSource();
    public selectedColumns = new FormControl(InitialColumns);
    @ViewChild(MatSort, { static: true }) sort: MatSort;
    @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;

    constructor(private route: ActivatedRoute,
        private userService: UserService) { }

    ngOnInit(): void {
        this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);

        this.columns = AllColumns;
        this.displayColumns = InitialColumns;
        this.queryData();
    }

    public applyFilter(filterValue: string) {
        this.dataSource.filter = filterValue.trim().toLowerCase();
        this.dataSource.paginator.firstPage();
    }

    public getColumnName(value: string) {
        return ColumnMap[value];
    }

    public onSelectionChange(selectedCols: string[]) {
        this.selectedColumns = new FormControl(selectedCols);
        this.displayColumns = selectedCols;
        this.queryData();
    }

    private queryData() {
        this.route.queryParams.subscribe(x => {
            let ids = x["ids"] as number[];
            if (!ids) { return; }

            this.userService.getAll(ids, this.columns).subscribe((x) => {
                this.dataSource = new MatTableDataSource(x);
                this.dataSource.sort = this.sort;
                this.dataSource.paginator = this.paginator;
            });
        });
    }
}
