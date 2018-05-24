import { OnInit } from '@angular/core';
import { Http } from '@angular/http';
export declare class AthleteData implements OnInit {
    private _http;
    constructor(_http: Http);
    ngOnInit(): void;
    loadAthleteData(): void;
    loadPerformanceScores(): void;
    loadSettings(): void;
    saveSettings(): void;
}
