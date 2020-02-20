import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
    selector: 'app-syllabus',
    templateUrl: './syllabus.component.html'
})

export class SyllabusComponent implements OnInit {
    public syllabi: Syllabus[];
    public trades: Trade[];
    public levels: TradeLevel[];
    public baseUrl: string
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
        }, error => console.log(error));
    }
    searchForm: FormGroup;

    ngOnInit() {
        this.searchForm = this.formBuilder.group({

            tradeId: [0],
            levelId: [0],
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
