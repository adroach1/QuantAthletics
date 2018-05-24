import { OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { UserSearch, User } from '../users/user';
export declare class UserListComponent implements OnInit {
    private _http;
    constructor(_http: Http);
    ngOnInit(): void;
    userSearch: UserSearch;
    searchUsers(): void;
    users: User[];
    isDataAvailable: boolean;
}
