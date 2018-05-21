import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { FormsModule } from '@angular/forms';


@Component({
    selector: 'athlete-Profile',
    templateUrl: '/app/athleteProfile/athleteProfile.component.template.html',
    providers: []
})
export class AthleteProfileComponent implements OnInit {
    constructor(private _http: Http) {
        
    }

    public ngOnInit(): void {
        this.loadAthleteProfile();
    }
    public athleteProfile: AthleteProfile;

    public isDataAvailable: boolean = false;

    public createAthleteProfile(): void {
        console.log("createAthleteProfile");
        var x = this._http.post("/api/AthleteProfile/CreateAthleteProfile",this.athleteProfile)
            .subscribe((res) => { console.log(res); });
    }

    public loadAthleteProfile(): void {
        console.log("loadAthleteProfile");
        var x = this._http.get("/api/AthleteProfile/GetAthleteProfile")
            .subscribe((res) => {
                console.log(res);
                console.log("json=" + res.json());
                this.athleteProfile = res.json();
                this.isDataAvailable = true;
            });
    }

}

export interface AthleteProfile
{
    Guid: Object;
    SourceType: string;
    SourceAthleteId: string;
    SourceKey: string;
}