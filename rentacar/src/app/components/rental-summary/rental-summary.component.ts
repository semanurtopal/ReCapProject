import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Car } from 'src/app/models/car';
import { RentalItem } from 'src/app/models/rentalItem';
import { RentalService } from 'src/app/services/rental.service';

@Component({
  selector: 'app-rental-summary',
  templateUrl: './rental-summary.component.html',
  styleUrls: ['./rental-summary.component.css']
})
export class RentalSummaryComponent implements OnInit {

  rentalItems:RentalItem[]=[];

  constructor(private rentalService:RentalService,private toastrService:ToastrService) { }

  ngOnInit(): void {
    this.getRental();
  }

  getRental(){
    this.rentalItems= this.rentalService.list();
  }

  removeFromRental(car:Car){
    this.rentalService.removeFromRental(car);
    this.toastrService.error("Silindi", car.brandName)
  }

}
