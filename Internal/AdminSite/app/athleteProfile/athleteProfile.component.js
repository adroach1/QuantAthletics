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
let AthleteProfileComponent = class AthleteProfileComponent {
    constructor(_http) {
        this._http = _http;
        this.isDataAvailable = false;
    }
    ngOnInit() {
        this.loadAthleteProfile();
    }
    createAthleteProfile() {
        console.log("createAthleteProfile");
        var x = this._http.post("/api/AthleteProfile/CreateAthleteProfile", this.athleteProfile)
            .subscribe((res) => { console.log(res); });
    }
    loadAthleteProfile() {
        console.log("loadAthleteProfile");
        var x = this._http.get("/api/AthleteProfile/GetAthleteProfile")
            .subscribe((res) => {
            console.log(res);
            console.log("json=" + res.json());
            this.athleteProfile = res.json();
            this.isDataAvailable = true;
        });
    }
};
AthleteProfileComponent = __decorate([
    core_1.Component({
        selector: 'athlete-Profile',
        templateUrl: '/app/athleteProfile/athleteProfile.component.template.html',
        providers: []
    }),
    __metadata("design:paramtypes", [http_1.Http])
], AthleteProfileComponent);
exports.AthleteProfileComponent = AthleteProfileComponent;
//# sourceMappingURL=athleteProfile.component.js.map