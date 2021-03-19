import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Car } from 'src/app/models/car';
import { RentItem } from 'src/app/models/rentItem';
import { RentService } from 'src/app/services/rent.service';

@Component({
  selector: 'app-rent-summary',
  templateUrl: './rent-summary.component.html',
  styleUrls: ['./rent-summary.component.css']
})
export class RentSummaryComponent implements OnInit {

  rentItems:RentItem[]=[];

  constructor(private rentService:RentService, private toastrService:ToastrService) { }

  ngOnInit(): void {
    this.getRent();
  }

  getRent(){
    this.rentItems=this.rentService.list();
  }

  removeFromRent(car:Car){
    this.rentService.removeFromRent(car);
    this.toastrService.error("Silindi", car.brandName)
  }

}
