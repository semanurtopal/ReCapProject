import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StorageService {

  constructor() { }

  addToLocal(key: string, value: string){
    localStorage.setItem(key, value);
  }

  deleteFromLocal(key: string){
    localStorage.removeItem(key);
  }

  getFromLocal(key: string){
    return localStorage.getItem(key);
  }

  ////////////////////////////////////////////////////////////

  addToSession(key: string, value: string){
    sessionStorage.setItem(key, value);
  }

  deleteFromSession(key: string){
    sessionStorage.removeItem(key);
  }

  getFromSession(key: string){
    return sessionStorage.getItem(key);
  }
}
