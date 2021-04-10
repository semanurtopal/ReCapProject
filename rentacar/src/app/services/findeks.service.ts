import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { SingleResponseModel } from '../models/singleResponseModel';

@Injectable({
  providedIn: 'root'
})
export class FindeksService {
  apiUrl = environment.apiUrl;

  constructor(private httpClient:HttpClient) { }

  calculate() : Observable<SingleResponseModel<number>>{
    let newPath = this.apiUrl + "findekses/calculate"
    return this.httpClient.get<SingleResponseModel<number>>(newPath)
  }
}
