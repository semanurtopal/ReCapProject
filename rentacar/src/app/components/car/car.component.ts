import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Car } from 'src/app/models/car';
import { CarImage } from 'src/app/models/carImage';
import { CarService } from 'src/app/services/car.service';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.css']
})
export class CarComponent implements OnInit {

  cars:Car[] = [];
  carImages: CarImage;
  dataLoaded=false;

  imagePath: string = 'https://localhost:44311/Images/default.png';

  constructor(private carService:CarService, private activatedRoute:ActivatedRoute) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params=>{
      if(params["colorId"]){
        this.getCarsByColorId(params["colorId"])
      }else if(params["brandId"]){
        this.getCarsByBrandId(params["brandId"])
      }else{
        this.getCarsByDetails()
      }
    })
  }

  getImageClass(car: number) {}

  getCarsByDetails(){
    this.carService.getCarsByDetails().subscribe(response=>{
      this.cars=response.data
      this.dataLoaded=true;
    });
  }

  getCarDetailsByCarId(carId: number) {
    this.carService.getCarDetailsByCarId(carId).subscribe((response) => {
      this.cars = response.data;
      this.dataLoaded = true;
    });
  }

  getCarsByColorId(colorId:number){
    this.carService.getCarsByColorId(colorId).subscribe(response=>{
      this.cars=response.data
      this.dataLoaded=true;
    })
  }

  getCarsByBrandId(brandId:number){
    this.carService.getCarsByBrandId(brandId).subscribe(response=>{
      this.cars=response.data
      this.dataLoaded=true;
    })
  }

}
