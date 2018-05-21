import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';


@Component({
    selector: 'athlete-Data',
    templateUrl: '/app/athleteData/athleteData.component.template.html',
    providers: []
})

export class AthleteData implements OnInit {
    constructor(private _http: Http) {
        
    }

    public ngOnInit(): void {
        
    }

    public loadAthleteData(): void {
        console.log("loadAthleteData");
        var x = this._http.get("/api/LoadAthleteData")
            .subscribe((res) => { console.log(res); });
    }
    public loadPerformanceScores(): void {
        console.log("loadPerformanceScores");
        var x = this._http.get("/api/PerformanceScores")
            .subscribe((res) => { console.log(res); });
    }

    public loadSettings(): void {
        console.log("loadSettings");
        var x = this._http.get("/api/Settings")
            .subscribe((res) => { console.log(res); });
    }

    public saveSettings(): void {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        console.log("loadSettings");
        var x = this._http.post("/api/Settings", "test", options)
            .subscribe((res) => { console.log(res); });
    }
}