import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { environment } from './../../../environments/environment';
import { Login } from './login.model';
import { Observable, EMPTY } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private snackBar: MatSnackBar, private http: HttpClient) { }
  
  showMessage(msg: string, isError: boolean = false): void {
    this.snackBar.open(msg, "X", {
      duration: 3000,
      horizontalPosition: "right",
      verticalPosition: "top",
      panelClass: isError ? ["msg-error"] : ["msg-success"],
    });
  }

  async login(login: Login){
    var basic = "Basic " + btoa(login.username + ':' + login.password);
    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': basic });
    let options = { headers: headers };
    const result = await this.http.post<any>(`${environment.authApi}`, null, options).toPromise();
    if(result.success){
      window.localStorage.setItem("token", result.success);
      return true;
    }
    this.errorHandler(result.error);
    return false;
  }
  errorHandler(e: string): Observable<any> {
    this.showMessage(e, true);
    return EMPTY;
  }
}
