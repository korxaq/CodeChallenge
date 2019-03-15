import { Injectable } from '@angular/core';
import {
    HttpHeaders,
    HttpClient
} from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/share';

import { User, UserProjectCalculated } from '../models';
import { map } from 'rxjs/operators';
import { from } from 'rxjs/observable/from';

@Injectable()
export class CodeChallengeService {
    codeChallengeEndpoint = '/codeChallengeService';

    headers = new HttpHeaders({
        'Cache-Control': 'no-cache',
        Pragma: 'no-cache',
        Expires: '-1',
    });

    constructor(private http: HttpClient) { }

    getAllUsers(): Observable<Array<User>> {
        const getAllUsersEndpoint = this.codeChallengeEndpoint + '/Users'
        const observable = new Observable<Array<User>>(observer => {
            this.http.get<Array<User>>(getAllUsersEndpoint, { headers: this.headers }).subscribe(
                response => {
                    observer.next(response);
                    observer.complete();
                },
                error => {
                    observer.error(error);
                }
            )
        });

        return observable;
    }

}