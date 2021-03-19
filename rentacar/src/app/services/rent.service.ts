import { Injectable } from '@angular/core';
import { Car } from '../models/car';
import { RentItem } from '../models/rentItem';
import { RentItems } from '../models/rentItems';

@Injectable({
  providedIn: 'root'
})
export class RentService {

  constructor() { }

  rent(car:Car){
    let item = RentItems.find(c=>c.car.carId===car.carId);
    if(item){
      item.date+=1;
    }else{
      let rentItem = new RentItem();
      rentItem.car=car;
      rentItem.date=1;
      RentItems.push(rentItem)
    }
    
  }

  removeFromRent(car:Car){
    let item:RentItem=RentItems.find(c=>c.car.carId===car.carId);
    RentItems.splice(RentItems.indexOf(item),1);
  }

  list():RentItem[]{
    return RentItems;
  }
}
