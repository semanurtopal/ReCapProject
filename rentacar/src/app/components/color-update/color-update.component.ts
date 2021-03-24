import { Component, OnInit } from '@angular/core';
import {FormGroup,FormBuilder,FormControl,Validators} from '@angular/forms'
import { ToastrService } from 'ngx-toastr';
import { ColorService } from 'src/app/services/color.service';

@Component({
  selector: 'app-color-update',
  templateUrl: './color-update.component.html',
  styleUrls: ['./color-update.component.css']
})
export class ColorUpdateComponent implements OnInit {

  colorUpdateForm:FormGroup;
  constructor(private formBuilder:FormBuilder, private colorService:ColorService, 
    private toastrService:ToastrService) { }

  ngOnInit(): void {
    this.createColorUpdateForm();
  }

  createColorUpdateForm(){
    this.colorUpdateForm=this.formBuilder.group({
      
      colorName:["",Validators.required],
     
    })
  }

  update(){
    if(this.colorUpdateForm.valid){
      let colorModel=Object.assign({},this.colorUpdateForm.value)
      this.colorService.add(colorModel).subscribe(response=>{
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
