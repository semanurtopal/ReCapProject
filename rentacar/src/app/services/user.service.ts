import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ListResponseModel } from '../models/listResponseModel';
import { ResponseModel } from '../models/responseModel';
import { SingleResponseModel } from '../models/singleResponseModel';
import { UpdateUserModel } from '../models/updateUserModel';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  apiUrl = environment.apiUrl;

  constructor(private httpClient: HttpClient) { }

  getByMail(email:string) : Observable<SingleResponseModel<User>>{
    let newPath = this.apiUrl + "users/getbymail?email="
    return this.httpClient.get<SingleResponseModel<User>>(newPath + email)
  }

  getUsersByFindeksRating(findeksRating:number) : Observable<ListResponseModel<User>>{
    let newPath = this.apiUrl + "users/getuserfindeksrating?findeksRating=" + findeksRating
    return this.httpClient.get<ListResponseModel<User>>(newPath)
  }

  getById(id:number) : Observable<SingleResponseModel<User>>{
    let newPath = this.apiUrl + "users/getbyid?id="+id
    return this.httpClient.get<SingleResponseModel<User>>(newPath)
  }

  updateUser(user:UpdateUserModel) : Observable<ResponseModel>{
    let newPath = this.apiUrl + "users/update"
    return this.httpClient.post<ResponseModel>(newPath, user)
  }
}
