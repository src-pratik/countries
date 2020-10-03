import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { CountryService } from '../_services/country.service';

@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrls: ['./country.component.css']
})
export class CountryComponent implements OnInit {

  @Output() valuechange = new EventEmitter();
  @Output() loadcomplete = new EventEmitter();


  countryControl = new FormControl('', Validators.required);
  countries = null;

  constructor(private countryService: CountryService) { }

  ngOnInit(): void {
    this.countryService.getList().subscribe(data => {
      this.countries = data;
      this.loadcomplete.emit(null);
    }, err => {
      this.loadcomplete.emit(err);
    });
  }

  onValidate(): boolean {
    return this.countryControl.valid;
  }

  onSubmit(): void {
    if (this.onValidate() != true)
      return;

    this.countryService.getById(this.countryControl.value).subscribe(data => {
      this.countryService.getFlagById(this.countryControl.value).subscribe(flagData => {
        data.flag = flagData.flag;
        this.valuechange.emit(data);
      })
    });
  }

}
