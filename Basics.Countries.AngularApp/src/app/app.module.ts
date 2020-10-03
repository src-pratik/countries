import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './_shared/material/material.module';
import { HomeComponent } from './home/home.component';
import { LayoutModule as SharedLayoutModule } from './_shared/layout/layout.module';
import { CountryViewComponent } from './country-view/country-view.component';
import { CountryComponent } from './country/country.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CountryService } from './_services/country.service';
import { httpInterceptorProviders } from './_http-interceptors';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CountryViewComponent,
    CountryComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MaterialModule,
    SharedLayoutModule
  ],
  providers: [httpInterceptorProviders, CountryService],
  bootstrap: [AppComponent, HomeComponent]
})
export class AppModule { }
