import { ImageInfo } from './image-info.model';

export class User {
    id: number;
    firstName: string;
    lastName: string;
    email: string;
    userName: string;
    country: string;
    city: string;
    gender: string;
    images: ImageInfo[];

    static getDefaultUser(){
        let user = new User();
        user.id = -1;
        user.firstName = "";
        user.lastName = "";
        user.email = "";
        user.userName = "";
        user.country = "";
        user.city = "";
        user.gender = "";

        return user;
    }
}