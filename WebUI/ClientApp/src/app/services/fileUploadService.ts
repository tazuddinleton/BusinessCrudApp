import { HttpClient } from "@angular/common/http";
import { Inject } from "@angular/core";
export class FileUploadService{

    private api: string;
    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
        this.api = baseUrl + 'api/fileupload/';
    }

    upload(files: FormData) {
        return this.http.post<any>(this.api, files).pipe();
    }
}

