import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
    selector: 'app-syllabus-list',
    templateUrl: './syllabus-list.component.html'
})

export class SyllabusListComponent implements OnInit {
    public syllabi: Syllabus[];
    public trades: Trade[];
    public levels: TradeLevel[];
    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string
        , private formBuilder: FormBuilder
    ) {

        baseUrl = baseUrl
        http.get<Syllabus[]>(baseUrl + 'api/syllabus').subscribe(result => {
            this.syllabi = result;
        }, error => console.error(error));

        http.get<Trade[]>(baseUrl + 'api/trade').subscribe(result => {
            this.trades = result;
        }, error => console.log(error));

        http.get<TradeLevel[]>(baseUrl + 'api/tradelevel').subscribe(result => {
            this.levels = result;
            this.levelBackup = result;
        }, error => console.log(error));
    }
    searchForm: FormGroup;
    levelBackup: TradeLevel[];

    ngOnInit() {
        this.searchForm = this.formBuilder.group({

            tradeId: [''],
            levelId: [''],
        });
        console.log('calling on change');
        this.onTradeChange();
        
    }

    onTradeChange(): void {
        this.searchForm.get('tradeId').valueChanges.subscribe(x => {
            this.levels = this.levelBackup.filter(l => l.tradeId == (x || l.tradeId));
            this.searchForm.get('levelId').setValue('');
        });
    }
}
    

interface Syllabus {
    id: string,
    name: string,
    tradeId: string,
    tradeName: string,
    tradeLevelId: string,
    tradeLevelName: string,
    developmentOfficer: string,
    manager: string,
    activeDate: Date
}

interface Trade {
    id: string,
    title: string
}

interface TradeLevel {
    id: string,
    title: string,
    tradeId: string
}
