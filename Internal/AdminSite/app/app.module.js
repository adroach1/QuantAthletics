"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const platform_browser_1 = require("@angular/platform-browser");
const forms_1 = require("@angular/forms");
const app_component_1 = require("./app.component");
const dashboard_component_1 = require("./dashboard/dashboard.component");
const personalCabinet_component_1 = require("./personalCabinet/personalCabinet.component");
const athleteData_component_1 = require("./athleteData/athleteData.component");
const athleteProfile_component_1 = require("./athleteProfile/athleteProfile.component");
const userList_component_1 = require("./users/userList.component");
const app_routing_1 = require("./app.routing");
const http_1 = require("@angular/http");
let AppModule = class AppModule {
};
AppModule = __decorate([
    core_1.NgModule({
        imports: [platform_browser_1.BrowserModule, forms_1.FormsModule, app_routing_1.routing, http_1.HttpModule],
        providers: [],
        declarations: [app_component_1.AppComponent, dashboard_component_1.Dashboard, personalCabinet_component_1.PersonalCabinet, athleteData_component_1.AthleteData, athleteProfile_component_1.AthleteProfileComponent, userList_component_1.UserListComponent],
        bootstrap: [app_component_1.AppComponent]
    })
], AppModule);
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map