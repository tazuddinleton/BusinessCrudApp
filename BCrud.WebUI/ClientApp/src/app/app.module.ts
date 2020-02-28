import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SyllabusListComponent } from './syllabus/syllabus-list.component';
import { SyllabusComponent } from './syllabus/syllabus.component';
import { TradeService } from './services/trade.services';
import { TradeLevelService } from './services/tradelevel.service';
import { SyllabusService } from './services/syllabus.service';
import { LanguageService } from './services/language.service';
import { FileUploadService } from './services/fileUploadService';
import { UtilityService } from './services/utilityService';


@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
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
            { path: 'syllabus', component: SyllabusComponent },
            { path: 'syllabus/:id', component: SyllabusComponent }

        ])
    ],
    providers: [
        TradeService,
        TradeLevelService,
        SyllabusService,
        LanguageService,
        FileUploadService,
        UtilityService

    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
