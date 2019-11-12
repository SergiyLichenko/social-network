import { Component, OnInit, Input } from '@angular/core';
import { MediaService } from 'src/app/services/media.service';
import { DomSanitizer } from '@angular/platform-browser';
import { ImageInfo } from 'src/app/models/image-info.model';

@Component({
    selector: 'app-image',
    templateUrl: './image.component.html',
    styleUrls: ['./image.component.css']
})
export class ImageComponent implements OnInit {
    @Input() public info: ImageInfo;
    @Input("show-author") public showAuthor: boolean;
    public image: any;
    isImageLoading: boolean;

    constructor(private mediaService: MediaService,
        private domSanitizer: DomSanitizer) {
    }

    ngOnInit(): void {
        this.isImageLoading = true;
        this.mediaService.getByName(this.info.src).subscribe(data => {
            this.createImageFromBlob(data);
            this.isImageLoading = false;
        }, error => {
            this.isImageLoading = false;
            console.log(error);
        });
    }

    createImageFromBlob(image: Blob) {
        let reader = new FileReader();
        reader.addEventListener("load", () => {
            this.image = this.domSanitizer.bypassSecurityTrustUrl(reader.result as string);
        }, false);

        if (image) {
            reader.readAsDataURL(image);
        }
    }

    public getName(filePath: string){
        let fileName = filePath.replace(/^.*[\\\/]/, '');
        let lastIndex = fileName.lastIndexOf(".");
        fileName = fileName.substring(0, lastIndex);

        return fileName;
    }
}
