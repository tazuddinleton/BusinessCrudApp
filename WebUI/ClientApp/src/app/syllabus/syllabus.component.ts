import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators, FormArray, FormControl } from '@angular/forms';
import { SyllabusService } from '../services/syllabus.service';
import { TradeService } from '../services/trade.services';
import { TradeLevelService } from '../services/tradelevel.service';
import { Trade } from '../models/trade.model';
import { TradeLevel } from '../models/tradelevel.model';
import { Syllabus } from '../models/syllabus.model';
import { LanguageService } from '../services/language.service';
import { Router, ActivatedRoute } from '@angular/router';
import { debug } from 'util';
import { DatePipe } from '@angular/common';

@Component({
    selector: 'app-syllabus',
    templateUrl: './syllabus.component.html',
    providers: [DatePipe]
})
export class SyllabusComponent implements OnInit {

    syllabusId: string;
    levelBackup: TradeLevel[];
    public trades: Trade[];
    public levels: TradeLevel[];

    public syllabus: Syllabus;
    public languages: any[];

    constructor(private formbuilder: FormBuilder, private syllabusService: SyllabusService
        , private tradeService: TradeService, private tradeLevelService: TradeLevelService
        , private languageService: LanguageService, private router: Router, private route: ActivatedRoute
        , private datePipe: DatePipe
    ) { }

    syllabusForm: FormGroup;

    ngOnInit() {
        this.buildForm(new Syllabus('', '', '', '', '', '', '', ''));
        this.route.paramMap.subscribe(params => {
            this.syllabusId = params.get('id');
        });
        if (this.syllabusId) {
            this.syllabusService.getById(this.syllabusId).subscribe(data => {
                this.checkSelectedLang(data.languages);
                this.buildForm(data);
            });
        }
        this.loadData();
        
    }

    private checkSelectedLang(languages) {        
        languages.split(',').forEach(lang => {
            document.getElementById(lang).setAttribute('checked', 'checked');
        });
    }

    private uncheckAllLang() {
        this.languages.forEach(lang => {
            document.getElementById(lang.value).removeAttribute('checked');
        });
    }

    private buildForm(data: Syllabus) {
        let date = data.activeDate ? this.datePipe.transform(data.activeDate, 'yyyy-MM-dd') : null;
        let languages = data.languages ? data.languages.split(',') : [];

        this.syllabusForm = this.formbuilder.group({
            id: [data.id],
            name: [data.name, Validators.required],
            developmentOfficer: [data.developmentOfficer, Validators.required],
            manager: [data.manager, Validators.required],
            tradeId: [data.tradeId, Validators.required],
            tradeLevelId: [data.tradeLevelId, Validators.required],
            languages: this.formbuilder.array(languages, Validators.required),
            syllabusUrl: null,
            testPlanUrl: null,
            activeDate: [date, Validators.required]
        });
        this.onTradeChange();

    }

    onTradeChange(): void {
        this.syllabusForm.get('tradeId').valueChanges.subscribe(x => {
            this.levels = this.levelBackup.filter(l => l.tradeId == (x || l.tradeId));
            this.syllabusForm.get('tradeLevelId').setValue('');
        });
    }

    private loadData() {
        
        this.tradeService.getTrades().subscribe(result => this.trades = result);
        this.tradeLevelService.getTradLevels().subscribe(result => {
            this.levels = result;
            this.levelBackup = result;
        });
        this.languages = this.languageService.get();
        console.log(this.languages);
    }

    onCheckboxChange(event) {        
        const checkboxArray = <FormArray>this.syllabusForm.controls.languages;
        if (event.target.checked) {
            checkboxArray.push(new FormControl(event.target.value));
        } else {
            let index = checkboxArray.controls.findIndex(x => x.value == event.target.value)
            checkboxArray.removeAt(index);
            console.log(checkboxArray);
        }
    }

    browseForFile(id) {
        document.getElementById(id).click();
    }

    resetForm() {
        this.syllabusForm.reset();
        this.uncheckAllLang();
    }

    submit() {
        let syllabus = new Syllabus(
            this.syllabusForm.value.id,
            this.syllabusForm.value.name,
            this.syllabusForm.value.tradeId,
            this.syllabusForm.value.tradeLevelId,
            this.syllabusForm.value.developmentOfficer,
            this.syllabusForm.value.manager,
            this.syllabusForm.value.languages.join(','),
            this.syllabusForm.value.activeDate
        );

        if (syllabus.id) {
            this.update(syllabus);
        } else {
            this.add(syllabus);
        }

        
    }


    private add(syllabus) {

        this.syllabusService.add(syllabus).subscribe(response => {
            this.router.navigate(['']);
        }, error => console.log(error));
    }

    private update(syllabus) {

        this.syllabusService.update(syllabus).subscribe(response => {
            this.router.navigate(['']);
        }, error => console.log(error));
    }
}
