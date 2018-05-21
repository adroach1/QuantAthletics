import { ModuleWithProviders }  from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { Dashboard } from './dashboard/dashboard.component'
import { PersonalCabinet } from './personalCabinet/personalCabinet.component'
import { AthleteData } from './athleteData/athleteData.component'
import { AthleteProfileComponent } from './athleteProfile/athleteProfile.component'
import { UserListComponent } from './users/userList.component'

const appRoutes: Routes = [
    {
        path: '',
        component: Dashboard
    },
    {
        path: 'personal',
        component: PersonalCabinet
    },
    {
        path: 'athleteData',
        component: AthleteData
    },
    {
        path: 'athleteProfile',
        component: AthleteProfileComponent
    },
    {
        path: 'userList',
        component: UserListComponent
    },
    {
        path: '**',  // otherwise route.
        component: Dashboard
    }
];


export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);