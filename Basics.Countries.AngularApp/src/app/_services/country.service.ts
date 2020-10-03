import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Country } from '../_models/country';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CountryService {

  countryEndPoint: string = `${environment.apiURL}/country`;
  flagEndPoint: string = `${environment.apiURL}/flag`;

  constructor(private httpClient: HttpClient) { }

  getList() {
    return this.httpClient.get<Country[]>(`${this.countryEndPoint}/list`);
  }

  getById(id: string) {
    return this.httpClient.get<Country>(`${this.countryEndPoint}/` + id);
  }

  getFlagById(id: string) {
    return this.httpClient.get<any>(`${this.flagEndPoint}/` + id);
  }
}
