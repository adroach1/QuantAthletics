import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { Http, Response, Headers,RequestOptions,URLSearchParams } from '@angular/http';
import { UserSearch, User } from '../users/user';


@Component({
    selector: 'userList',
    templateUrl: '/app/users/userList.component.template.html',
    providers: []
})
export class UserListComponent implements OnInit {
    constructor(private _http: Http) {
        
    }

    public ngOnInit(): void {
        this.userSearch = new UserSearch();
        this.isDataAvailable = true;
    }
    public userSearch :UserSearch;
    public searchUsers(): void {
        let options = new RequestOptions({search:this.userSearch.getSearchParams()});
        console.log("searching users "+options);
        var x = this._http.get("/api/user/SearchUsers",options)
            .subscribe((res) => {
                console.log(res);
                this.users = res.json()
            });
    }

    public users: User[];
    public isDataAvailable: boolean = false;

}


