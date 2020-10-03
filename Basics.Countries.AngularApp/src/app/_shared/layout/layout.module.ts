import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { MaterialModule } from '../material/material.module';
import { LeftSidebarComponent } from './components/left-sidebar/left-sidebar.component';



@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent,
    LeftSidebarComponent
  ],
  bootstrap: [
    HeaderComponent,
    FooterComponent,
    LeftSidebarComponent
  ],
  imports: [
    CommonModule,
    MaterialModule
  ],
  exports: [
    HeaderComponent,
    FooterComponent,
    LeftSidebarComponent
  ]
})
export class LayoutModule { }
