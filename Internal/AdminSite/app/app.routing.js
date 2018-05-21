"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const router_1 = require("@angular/router");
const dashboard_component_1 = require("./dashboard/dashboard.component");
const personalCabinet_component_1 = require("./personalCabinet/personalCabinet.component");
const athleteData_component_1 = require("./athleteData/athleteData.component");
const athleteProfile_component_1 = require("./athleteProfile/athleteProfile.component");
const userList_component_1 = require("./users/userList.component");
const appRoutes = [
    {
        path: '',
        component: dashboard_component_1.Dashboard
    },
    {
        path: 'personal',
        component: personalCabinet_component_1.PersonalCabinet
    },
    {
        path: 'athleteData',
        component: athleteData_component_1.AthleteData
    },
    {
        path: 'athleteProfile',
        component: athleteProfile_component_1.AthleteProfileComponent
    },
    {
        path: 'userList',
        component: userList_component_1.UserListComponent
    },
    {
        path: '**',
        component: dashboard_component_1.Dashboard
    }
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
//# sourceMappingURL=app.routing.js.map