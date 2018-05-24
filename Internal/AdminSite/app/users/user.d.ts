import { URLSearchParams } from '@angular/http';
export declare class User {
    Id: number;
    Username: string;
    Password: string;
    EmailAddress: string;
    FirstName: string;
    LastName: string;
    LastModified: Date;
    TempSessionId: string;
}
export declare class UserSearch {
    Id: number;
    Username: string;
    EmailAddress: string;
    getSearchParams(): URLSearchParams;
}
