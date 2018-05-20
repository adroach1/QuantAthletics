import { Component } from '@angular/core';

import { NavController } from 'ionic-angular';

@Component({
  selector: 'page-setup',
  templateUrl: 'setup.html'
})
export class SetupPage {

  constructor(public navCtrl: NavController) {

  }
  
  onLink(url: string) {
      window.open(url);
  }

  stravaStart() {
      window.open('http://www.strava.com');
  }
}
