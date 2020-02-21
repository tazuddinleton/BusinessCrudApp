import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Syllabus } from '../models/syllabus.model';
import { Trade } from '../models/trade.model';
import { TradeLevel } from '../models/tradelevel.model';
import { SyllabusService } from '../services/syllabus.service';
import { TradeService } from '../services/trade.services';
import { TradeLevelService } from '../services/tradelevel.service';

@Component({
    selector: 'app-syllabus-list',
    templateUrl: './syllabus-list.component.html'
})

export class SyllabusListComponent implements OnInit {

    levelBackup: TradeLevel[];

    public syllabi: Syllabus[];
    public trades: Trade[];
    public levels: TradeLevel[];
    constructor(private formBuilder: FormBuilder, private router: Router, private syllabusService: SyllabusService
        , private tradeService: TradeService, private tradeLevelService: TradeLevelService
    ) {}

    searchForm: FormGroup;
   

    ngOnInit() {

        this.loadData();

        this.searchForm = this.formBuilder.group({

            tradeId: [''],
            levelId: [''],
        });        
        this.onTradeChange();
        
    }

    onTradeChange(): void {
        this.searchForm.get('tradeId').valueChanges.subscribe(x => {
            this.levels = this.levelBackup.filter(l => l.tradeId == (x || l.tradeId));
            this.searchForm.get('levelId').setValue('');
        });
    }

    addSyllabus() {
        this.router.navigate(['syllabus']);
    }

    editSyllabus(id) {
        this.router.navigate(['syllabus/'+id]);
    }


    private loadData() {
        this.syllabusService.getAll().subscribe(result => this.syllabi = result);
        this.tradeService.getTrades().subscribe(result => this.trades = result);
        this.tradeLevelService.getTradLevels().subscribe(result => {
            this.levels = result;
            this.levelBackup = result;
        });  
    }
}
    

