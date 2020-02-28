import { HttpClient } from "@angular/common/http";
import { Inject } from "@angular/core";
import { Trade } from "../models/trade.model";


export class TradeService {
    private api: string;
    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
        this.api = baseUrl + 'api/trade/';
    }

    getTrades() {
        return this.http.get<Trade[]>(this.api);
    }
}
