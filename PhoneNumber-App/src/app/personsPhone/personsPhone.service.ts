import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Person } from "./person";
import { Observable } from "rxjs";

@Injectable()
export class PersonsPhoneService {

    constructor(private http: HttpClient) { }

    protected UrlService: string = "http://localhost:5000/api/";

    getPersons() : Observable<Person[]> {
        return this.http.get<Person[]>(this.UrlService + "person");
    }
}