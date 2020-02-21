import { HttpClient } from "@angular/common/http";
import { Inject } from "@angular/core";
import { TradeLevel } from "../models/tradelevel.model";


export class TradeLevelService {
    private api: string;
    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
        this.api = baseUrl + 'api/tradelevel/';
    }

    getTradLevels() {
        return this.http.get<TradeLevel[]>(this.api);
    }
}
