import { Component, OnInit } from '@angular/core';
import { MediaService } from 'src/app/services/media.service';
import { ImageInfo } from 'src/app/models/image-info.model';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-media',
    templateUrl: './media.component.html',
    styleUrls: ['./media.component.css']
})
export class MediaComponent implements OnInit {
    public imageInfos: ImageInfo[];
    private count = 100;
    private offset = 0;

    constructor(
        private route: ActivatedRoute,
        private mediaService: MediaService) {
    }

    ngOnInit(): void {
        this.route.queryParams.subscribe(x => {
            let tag = x["tag"];
            if (tag) {
                this.mediaService.getByTag(tag).subscribe(x => this.imageInfos = x);
            } else {
                this.mediaService.queryMedia({
                    count: this.count,
                    offset: this.offset
                }).subscribe(x => this.imageInfos = x);
            }
        });
    }
}
