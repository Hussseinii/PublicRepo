import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map'

import { AuthenticationService } from '../_services/auth.service';
import { Oppdrag, Tolk } from '../_models/models';

@Injectable()
export class OppdragService {
    constructor(
        private http: Http,
        private authenticationService: AuthenticationService) {
    }

    getOppdrag(): Observable<Oppdrag[]> {
        // add authorization header with jwt token
        let headers = new Headers({ 'Authorization': 'Bearer ' + this.authenticationService.token });
        let options = new RequestOptions({ headers: headers });

        // get users from api
        return this.http.get('/api/oppdrag', options)
            .map((response: Response) => response.json());
    }

    getOversettelser(): Observable<Oppdrag[]> {
        // add authorization header with jwt token
        let headers = new Headers({ 'Authorization': 'Bearer ' + this.authenticationService.token });
        let options = new RequestOptions({ headers: headers });

        // get users from api
        return this.http.get('/api/getOversettelser', options)
            .map((response: Response) => response.json());
    }

    getListeTolk(): Observable<Tolk[]> {
        // add authorization header with jwt token
        let headers = new Headers({ 'Authorization': 'Bearer ' + this.authenticationService.token });
        let options = new RequestOptions({ headers: headers });

        // get users from api
        return this.http.get('/api/getListeTolk', options)
            .map((response: Response) => response.json());
    }
}