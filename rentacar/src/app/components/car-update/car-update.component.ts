import { Component, OnInit } from '@angular/core';
import {FormGroup,FormBuilder,FormControl,Validators} from '@angular/forms'
import { ToastrService } from 'ngx-toastr';
import { CarService } from 'src/app/services/car.service';

@Component({
  selector: 'app-car-update',
  templateUrl: './car-update.component.html',
  styleUrls: ['./car-update.component.css']
})
export class CarUpdateComponent implements OnInit {

  carUpdateForm:FormGroup;
  constructor(private formBuilder:FormBuilder, 
    private carService:CarService, private toastrService:ToastrService) { }


  ngOnInit(): void {
    this.createCarUpdateForm();
  }

  createCarUpdateForm(){
    this.carUpdateForm=this.formBuilder.group({
      brandId:["",Validators.required],
      colorId:["",Validators.required],
      carName:["",Validators.required],
      modelYear:["",Validators.required],
      dailyPrice:["",Validators.required],
      description:["",Validators.required],
      available:["",Validators.required],

    })
  }

  update(){
    if(this.carUpdateForm.valid){
      let carModel=Object.assign({},this.carUpdateForm.value)
      this.carService.add(carModel).subscribe(response=>{
        this.toastrService.success(response.message,"Başarılı")
      },responseError=>{
        if(responseError.error.Errors.length>0){
          for(let i=0; i<responseError.error.Errors.length; i++){
            this.toastrService.error(responseError.error.Errors[i],
              "Doğrulama hatası")

          }
        }
      })
    }else{
      this.toastrService.error("Formunuz eksik","Dikkat")
    }
    
  }

}
