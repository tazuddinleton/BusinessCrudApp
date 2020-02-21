export class Syllabus {
    id: string;
    name: string;
    tradeId: string;
    tradeName: string;
    tradeLevelId: string;
    tradeLevelName: string;
    developmentOfficer: string;
    manager: string;
    languages: string;
    activeDate?: Date;

    constructor(id: string, name: string, tradeId: string,
        tradeLevelId: string, devOfficer: string, manager: string,
        languages: string, activeDate: string
    ) {
        this.id = id;
        this.name = name;
        this.tradeId = tradeId;
        this.tradeLevelId = tradeLevelId;
        this.developmentOfficer = devOfficer;
        this.manager = manager;
        this.languages = languages;
        this.activeDate = activeDate != '' ? new Date(activeDate): null;
    }



    setTradeName(tradeName: string) {
        this.tradeName = tradeName;
    }

    setTradeLevelName(tradeLevelName: string) {
        this.tradeLevelName = tradeLevelName;
    }
}
