import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Payment } from '../models/payment';
import { ResponseModel } from '../models/responseModel';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {

  constructor(private httpClient: HttpClient) {}

  addUrl: string = 'https://localhost:44311/api/payments/add';

  addPayment(payment: Payment): Observable<ResponseModel> {
    return this.httpClient.post<ResponseModel>(this.addUrl, payment);
  }
}
