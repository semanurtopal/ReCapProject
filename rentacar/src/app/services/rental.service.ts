import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Car } from '../models/car';
import { ListResponseModel } from '../models/listResponseModel';
import { Rental } from '../models/rental';
import { RentItems } from '../models/rentItems';
import { RentalItems } from '../models/rentalItems';
import { RentItem } from '../models/rentItem';
import { RentalItem } from '../models/rentalItem';

@Injectable({
  providedIn: 'root'
})
export class RentalService {

  apiUrl='https://localhost:44311/api/rentals/getall'


  constructor(private httpClient:HttpClient) { }

  getRentals():Observable<ListResponseModel<Rental>>{
    return this.httpClient.get<ListResponseModel<Rental>>(this.apiUrl);
  }

  addToRental(car:Car){
    let rental = RentalItems.find(c=>c.car.carId===car.carId)
    if(rental){
      rental.rental.rentDate+=1;
    }else{
      let rentalItem = new RentalItem();
      rentalItem.car=car;
      rentalItem.rental.rentDate=1;
      RentalItems.push(rentalItem)
    }

  }

  removeFromRental(car:Car){
    let rental:RentalItem=RentalItems.find(c=>c.car.carId===car.carId);
    RentalItems.splice(RentalItems.indexOf(rental),1)
  }

  list():RentalItem[]{
    return RentalItems;
  }
}
