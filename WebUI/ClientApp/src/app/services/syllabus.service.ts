import { HttpClient } from "@angular/common/http";
import { Inject } from "@angular/core";
import { Syllabus } from "../models/syllabus.model";
import { map } from 'rxjs/operators';


export class SyllabusService {
    private api: string
    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
        this.api = baseUrl + 'api/syllabus/';
    }

    getAll() {
        return this.http.get<Syllabus[]>(this.api);
    }

    getById(id: string) {
        return this.http.get<Syllabus>(this.api + id);
    }

    add(syllabus: Syllabus) {
        return this.http.post(this.api, syllabus);
    }

    update(syllabus: Syllabus) {
        return this.http.put(this.api, syllabus);
    }

    deleve(id: string) {
        return this.http.delete(this.api + id);
    }
}
