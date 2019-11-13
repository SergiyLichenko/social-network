import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { UserService } from '../user.service';
import { User } from '../../models/user.model';

@Injectable()
export class UserResolver implements Resolve<Observable<User>> {
    constructor(private userService: UserService) { }

    resolve(route: ActivatedRouteSnapshot) {
        let userId = route.queryParams['id'];
        let fields = Object.getOwnPropertyNames(User.getDefaultUser());
       
        return this.userService.getById(userId, fields);
    }
}