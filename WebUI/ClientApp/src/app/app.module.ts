import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { SyllabusListComponent } from './syllabus/syllabus-list.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,    
    SyllabusListComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
      FormsModule,
      ReactiveFormsModule,
      RouterModule.forRoot([
          { path: '', component: SyllabusListComponent },      
      { path: 'counter', component: CounterComponent }
      
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
