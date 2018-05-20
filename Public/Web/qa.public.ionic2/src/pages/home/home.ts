import { Component } from '@angular/core';
import { OnInit } from '@angular/core'

import { NavController } from 'ionic-angular';
import {SetupPage} from "../setup/setup";

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage implements OnInit {

  constructor(public navCtrl: NavController) {

  }
  
  onLink(url: string) {
      window.open(url);
  }

  async ngOnInit() {
      if (!this.checkUserIsSetup()) {
          await this.delay(1000);
          this.navCtrl.push(SetupPage);
      }
      
  }

  checkUserIsSetup() {
      return false;
  }
  delay(ms: number) {
       return new Promise(resolve => setTimeout(resolve, ms));
  }

  stravaStart() {
      window.open('http://www.strava.com');
  }
}
