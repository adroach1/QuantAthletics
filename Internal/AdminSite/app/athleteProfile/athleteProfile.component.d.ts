import { OnInit } from '@angular/core';
import { Http } from '@angular/http';
export declare class AthleteProfileComponent implements OnInit {
    private _http;
    constructor(_http: Http);
    ngOnInit(): void;
    athleteProfile: AthleteProfile;
    isDataAvailable: boolean;
    createAthleteProfile(): void;
    loadAthleteProfile(): void;
}
export interface AthleteProfile {
    Guid: Object;
    SourceType: string;
    SourceAthleteId: string;
    SourceKey: string;
}
