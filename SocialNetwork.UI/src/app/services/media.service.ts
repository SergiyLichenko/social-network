import { Injectable } from '@angular/core';
import { Query } from '../models/query-media.model';
import { HttpClient } from '@angular/common/http';
import { ImageInfo } from '../models/image-info.model';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root',
})
export class MediaService {
    private BaseUrl = "https://localhost:44375/api/";

    constructor(private httpClient: HttpClient) {
    }

    public queryMedia(query: Query) {
        return this.httpClient.get<ImageInfo[]>(this.BaseUrl + "mediaFile/query", { params: query as any });
    }

    public getByName(name: string): Observable<Blob> {
        return this.httpClient.get(this.BaseUrl + "mediaFile/byName?fileName=" + name, { responseType: 'blob' });
    }

    public getByTag(tag: string) {
        return this.httpClient.get<ImageInfo[]>(this.BaseUrl + "mediaFile/byTag?tag=" + tag);
    }
}