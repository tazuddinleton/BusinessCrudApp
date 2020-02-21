import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SyllabusListComponent } from './syllabus/syllabus-list.component';
import { SyllabusComponent } from './syllabus/syllabus.component';
import { TradeService } from './services/trade.services';
import { TradeLevelService } from './services/tradelevel.service';
import { SyllabusService } from './services/syllabus.service';
import { LanguageService } from './services/language.service';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,    
        SyllabusListComponent,
        SyllabusComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
      FormsModule,
      ReactiveFormsModule,
      RouterModule.forRoot([
          { path: '', component: SyllabusListComponent },      
          { path: 'counter', component: CounterComponent },
          { path: 'syllabus', component: SyllabusComponent },
          { path: 'syllabus/:id', component: SyllabusComponent }
      
    ])
  ],
    providers: [
        TradeService,
        TradeLevelService,
        SyllabusService,
        LanguageService
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
