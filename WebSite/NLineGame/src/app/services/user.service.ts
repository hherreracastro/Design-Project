import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../entities/user';
import { Observable } from 'rxjs/Observable';
import { catchError, map, tap } from 'rxjs/operators';
import { of } from 'rxjs/observable/of';
import { Http, Response, Headers, RequestOptions, RequestMethod, URLSearchParams } from '@angular/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';


/*const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded' })
};*/

const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json'}) // , 'Accept':  'application/json' })
  /*requestOptions: new RequestOptions({method: RequestMethod.Post,
    headers: new HttpHeaders({ 'Content-Type': 'application/json'}))*/
};

@Injectable()
export class UserService {
  headers: Headers;
  options: RequestOptions;
  private userUrl = 'http://localhost:46158/users';  // URL to web api

  constructor(private http: HttpClient) {
    this.headers = new Headers({ 'Content-Type': 'application/json',
                                     'Accept': 'q=0.8;application/json;q=0.9' });
        this.options = new RequestOptions({ headers: this.headers });
  }

  loginUser (user: User): Observable<any> {
    const lbody = JSON.stringify(user);
     const hearderOptions = new Headers({'Content-Type': 'application/json'});
     const requestOptions = new RequestOptions({method: RequestMethod.Post, headers: hearderOptions});
     return this.http.post(this.userUrl + '/login', lbody, httpOptions); /* .pipe(
      tap((users: User) => alert(`Login user ${users.email}`)),
      catchError(this.handleError<User>('loginUser'))
    );*/
  }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      alert(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

}
