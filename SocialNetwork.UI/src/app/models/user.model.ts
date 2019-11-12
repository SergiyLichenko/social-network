export class User {
    id: number;
    firstName: string;

    static getDefaultUser(){
        let user = new User();
        user.firstName = "";
        user.id = -1;

        return user;
    }
}