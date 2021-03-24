import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BrandComponent } from './components/brand/brand.component';
import { CarImageComponent } from './components/car-image/car-image.component';
import { CarComponent } from './components/car/car.component';
import { ColorComponent } from './components/color/color.component';
import { CustomerComponent } from './components/customer/customer.component';
import { RentalComponent } from './components/rental/rental.component';
import { CarImageService } from './services/car-image.service';


const routes: Routes = [
  {
    path:"", component:CarComponent    
  },
  {
    path:"cars", component:CarComponent   
  },
  {
    path:"cars/brand/:brandid", component:CarComponent   
  },
  {
    path:"cars/color/:colorid", component:CarComponent   
  },
  {
    path:"customers",  component:CustomerComponent
  },
  {
    path:"rentals",  component:RentalComponent
  },
  {
    path:"car-image/:carId",  component:CarImageComponent
  },
  { path:"cars/carDetailAndImagesDto/:car", component:CarComponent},
  { path:"cars/add", component:CarComponent},
  { path:"cars/update", component:CarComponent},
  { path:"brands/add", component:BrandComponent},
  { path:"brands/update", component:BrandComponent},
  { path:"colors/add", component:ColorComponent},
  { path:"colors/update", component:ColorComponent},






];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
