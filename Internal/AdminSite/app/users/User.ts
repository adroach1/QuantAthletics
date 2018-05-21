import {URLSearchParams } from '@angular/http';

export class User {
    Id: number;
    Username: string;
    Password: string;
    EmailAddress: string;
    FirstName: string;
    LastName: string;
    LastModified: Date;
    TempSessionId: string;
}

export class UserSearch {
    Id: number;
    Username: string;
    EmailAddress: string;

    public getSearchParams(): URLSearchParams {
        var params = new URLSearchParams();
        if (this.Id != null)
            params.append("Id", this.Id.toString());
        if (this.Username != null)
            params.append("Username", this.Username);
        if (this.EmailAddress != null)
            params.append("EmailAddress", this.EmailAddress);
        return params;
    }
}
