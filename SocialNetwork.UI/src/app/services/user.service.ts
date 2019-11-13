import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../models/user.model';

@Injectable({
    providedIn: 'root',
})
export class UserService {
    private BaseUrl = "https://localhost:44371/api/";

    constructor(private httpClient: HttpClient) {
    }

    public getById(userId: number, fields: string[]) {
        let headers = new HttpHeaders();
        headers = headers.set('Content-Type', 'application/json; charset=utf-8');

        let query = `{user(id:${userId}) { ${fields.join(",")}}}`;
        let json = JSON.stringify(query);

        return this.httpClient.post<User>(this.BaseUrl + "user/getById", json, { headers: headers });
    }

    public getAll(userIds: number[], fields: string[]) {
        let headers = new HttpHeaders();
        headers = headers.set('Content-Type', 'application/json; charset=utf-8');

        let queryIds = userIds.length > 0 ? `(ids: [${userIds.join(",")}])` : "";
        let query = `{users${queryIds} { ${fields.join(",")}}}`;
        let json = JSON.stringify(query);

        return this.httpClient.post<User[]>(this.BaseUrl + "user/getAll", json, { headers: headers });
    }
}