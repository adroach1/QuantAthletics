"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const http_1 = require("@angular/http");
let AthleteData = class AthleteData {
    constructor(_http) {
        this._http = _http;
    }
    ngOnInit() {
    }
    loadAthleteData() {
        console.log("loadAthleteData");
        var x = this._http.get("/api/LoadAthleteData")
            .subscribe((res) => { console.log(res); });
    }
    loadPerformanceScores() {
        console.log("loadPerformanceScores");
        var x = this._http.get("/api/PerformanceScores")
            .subscribe((res) => { console.log(res); });
    }
    loadSettings() {
        console.log("loadSettings");
        var x = this._http.get("/api/Settings")
            .subscribe((res) => { console.log(res); });
    }
    saveSettings() {
        let headers = new http_1.Headers({ 'Content-Type': 'application/json' });
        let options = new http_1.RequestOptions({ headers: headers });
        console.log("loadSettings");
        var x = this._http.post("/api/Settings", "test", options)
            .subscribe((res) => { console.log(res); });
    }
};
AthleteData = __decorate([
    core_1.Component({
        selector: 'athlete-Data',
        templateUrl: '/app/athleteData/athleteData.component.template.html',
        providers: []
    }),
    __metadata("design:paramtypes", [http_1.Http])
], AthleteData);
exports.AthleteData = AthleteData;
//# sourceMappingURL=athleteData.component.js.map