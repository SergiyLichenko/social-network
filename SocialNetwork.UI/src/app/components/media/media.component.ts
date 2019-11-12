import { Component, OnInit } from '@angular/core';
import { MediaService } from 'src/app/services/media.service';
import { ImageInfo } from 'src/app/models/image-info.model';

@Component({
    selector: 'app-media',
    templateUrl: './media.component.html',
    styleUrls: ['./media.component.css']
})
export class MediaComponent implements OnInit {
    public imageInfos: ImageInfo[];
    private count = 10;
    private offset = 0;

    constructor(private mediaService: MediaService) {
    }

    ngOnInit(): void {
        this.mediaService.queryMedia({
            count: this.count,
            offset: this.offset
        }).subscribe(x => this.imageInfos = x);
    }

    public getName(filePath: string){
        let fileName = filePath.replace(/^.*[\\\/]/, '');
        let lastIndex = fileName.lastIndexOf(".");
        fileName = fileName.substring(0, lastIndex);

        return fileName;
    }
}
