import { Component, OnInit } from '@angular/core';
import { Country } from '../_models/country';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  _leftsidebarOpen: boolean = true;
  selectedCountry: Country = null;

  errormessage: string = "Loading data from server...";

  constructor() { }

  ngOnInit(): void {
  }

  handleToggleLeftSideBar(e: any) {
    this._leftsidebarOpen = !this._leftsidebarOpen;
  }

  onSelectedCountryChange(e: any) {
    this.selectedCountry = e;
    if (e == undefined) this.errormessage = "No data found."; else this.errormessage = null;
  }

  onCountryLoadComplete(e: any) {
    if (e == null) {
      this.errormessage = null;
      return;
    }
    this.errormessage = `Error : Unable to load data. Details : ${e.message}`;
  }
}
