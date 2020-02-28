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
import { FileUploadService } from '../services/fileUploadService';
import { UtilityService } from '../services/utilityService';

@Component({
    selector: 'app-syllabus',
    templateUrl: './syllabus.component.html',
    providers: [DatePipe]
})
export class SyllabusComponent implements OnInit {

    syllabusId: string;
    levelBackup: TradeLevel[];
    syllabusFile: File;
    testPlanFile: File;


    public fileTypeError: any;
    public currentFiletype: string;
    public trades: Trade[];
    public levels: TradeLevel[];

    public syllabus: Syllabus;

    public languages: any[];

    constructor(private formbuilder: FormBuilder, private syllabusService: SyllabusService
        , private tradeService: TradeService, private tradeLevelService: TradeLevelService
        , private languageService: LanguageService, private router: Router, private route: ActivatedRoute
        , private datePipe: DatePipe, private fileUploadService: FileUploadService, private utilityService: UtilityService
    ) { }

    syllabusForm: FormGroup;

    ngOnInit() {
        this.buildForm(new Syllabus('', '', '', '', '', '', '', '', '', '', '', ''));
        this.route.paramMap.subscribe(params => {
            this.syllabusId = params.get('id');
        });
        if (this.syllabusId) {
            this.syllabusService.getById(this.syllabusId).subscribe(data => {
                this.checkSelectedLang(data.languages);
                this.buildForm(data);
                this.syllabus = data;
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

    onFileChange(event, fileType) {
        debugger;
        this.currentFiletype = fileType;
        if (!event.target.files)
            return;

        let file = event.target.files[0];
        if (file.type != 'application/pdf' && file.type != 'application/doc' && file.type != 'application/docx') {
            this.fileTypeError = true;
            return;
        }

        if (fileType == 'syllabus') {
            this.syllabusFile = file;
            this.fileTypeError = false;
        } else {
            this.testPlanFile = file;
            this.fileTypeError = false;
        }
    }

    resetForm() {
        this.syllabusForm.reset();
        this.uncheckAllLang();
        this.syllabusFile = null;
        this.testPlanFile = null;
    }

    submit() {

        const syllabusHash = this.syllabusFile != null ?
            this.utilityService.hashifyFilename(this.syllabusFile.name) : null;

        const testPlanHash = this.testPlanFile != null ? 
            this.utilityService.hashifyFilename(this.testPlanFile.name) : null;
        
        const formData = new FormData();
        if (syllabusHash != null) {
            formData.append('file', this.syllabusFile, syllabusHash);
        }
        if (testPlanHash != null) {
            formData.append('file', this.testPlanFile, testPlanHash);
        }
        
        this.fileUploadService.upload(formData).subscribe(response => {            
            let syllabusUrl:string;
            let testPlanUrl: string;

            if (syllabusHash) {
                syllabusUrl = this.syllabusFile != null ? response[syllabusHash] : this.syllabus.syllabusUrl;
            }
            if (testPlanHash) {
                testPlanUrl = this.testPlanFile != null ? response[testPlanHash] : this.syllabus.testPlanUrl;
            }

            let syllabus = new Syllabus(
                this.syllabusForm.value.id,
                this.syllabusForm.value.name,
                this.syllabusForm.value.tradeId,
                this.syllabusForm.value.tradeLevelId,
                this.syllabusFile != null ? this.syllabusFile.name : this.syllabus.syllabusFilename,
                syllabusUrl || this.syllabus.syllabusUrl,
                this.testPlanFile != null ? this.testPlanFile.name : this.syllabus.testPlanFilename,
                testPlanUrl || this.syllabus.testPlanUrl,
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
        });
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
