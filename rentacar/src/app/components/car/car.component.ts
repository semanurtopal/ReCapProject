import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Brand } from 'src/app/models/brand';
import { Car } from 'src/app/models/car';
import { CarDetailAndImagesDto } from 'src/app/models/carDetailAndImagesDto';
import { CarImage } from 'src/app/models/carImage';
import { Color } from 'src/app/models/color';
import { BrandService } from 'src/app/services/brand.service';
import { CarService } from 'src/app/services/car.service';
import { ColorService } from 'src/app/services/color.service';
import { RentService } from 'src/app/services/rent.service';
import { RentalService } from 'src/app/services/rental.service';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.css']
})
export class CarComponent implements OnInit {

  cars:Car[] = [];
  carImages: CarImage;
  brands:Brand;
  colors:Color;
  carDetailAndImagesDto: CarDetailAndImagesDto;
  currentCarDetails:CarDetailAndImagesDto;
  dataLoaded=false;
  filterText="";

  imagePath: string = 'https://localhost:44311/Images/default.png';

  constructor(private carService:CarService, private activatedRoute:ActivatedRoute, 
    private toastrService:ToastrService, private rentService:RentService, 
    private rentalService:RentalService,private brandService:BrandService, private colorService:ColorService) { }

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

  setCurrentCarDetails(carDetailAndImagesDto:CarDetailAndImagesDto){
    this.currentCarDetails=carDetailAndImagesDto;
  }

  getCurrentCarDetailsClass(carDetailAndImagesDto:CarDetailAndImagesDto){
    if(carDetailAndImagesDto==this.currentCarDetails){
      return "list-group-item active"
    }else{
      return "list-group-item"
    }
  }

  getAllCarDetailsClass(){
    if(!this.currentCarDetails){
      return "list-group-item active"
    }else{
      return "list-group-item"
    }
  }

  rent(car:Car){
    this.toastrService.success("Araç kiralandı", car.brandName)
    this.rentService.rent(car);
  }

  addToRental(car:Car){
    this.toastrService.success("Araç kiralandı", car.brandName)
    this.rentalService.addToRental(car);
  }

}
