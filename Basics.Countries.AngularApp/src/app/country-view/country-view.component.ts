import { Component, Input, OnInit } from '@angular/core';
import { Country } from '../_models/country';

@Component({
  selector: 'app-country-view',
  templateUrl: './country-view.component.html',
  styleUrls: ['./country-view.component.css']
})
export class CountryViewComponent implements OnInit {

  @Input() country: Country;

  constructor() { }

  ngOnInit(): void {
  }

}
