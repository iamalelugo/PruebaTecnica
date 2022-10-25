import { Inject, Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Persona } from 'src/app/models';
import { catchError, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  private baseUrl = environment.apiUrl

  constructor(private  http: HttpClient) { }

  getPersona(): Observable<any>{
    return this.http.get<any>(this.baseUrl);
  }

  createPersona(persona: any, ): Observable<any>{
    return this.http.post(this.baseUrl, persona)
    .pipe(catchError(persona));
    }

}
