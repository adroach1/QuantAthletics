import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent }   from './app.component';
import { Dashboard } from './dashboard/dashboard.component'
import { PersonalCabinet } from './personalCabinet/personalCabinet.component'
import { AthleteData } from './athleteData/athleteData.component'
import { AthleteProfileComponent } from './athleteProfile/athleteProfile.component'
import { UserListComponent} from './users/userList.component'
import { routing } from './app.routing';
import { HttpModule } from '@angular/http';

@NgModule({
    imports: [BrowserModule,FormsModule, routing, HttpModule],
    providers: [],
    declarations: [AppComponent, Dashboard, PersonalCabinet, AthleteData, AthleteProfileComponent, UserListComponent],
    bootstrap: [AppComponent]
})

export class AppModule { }