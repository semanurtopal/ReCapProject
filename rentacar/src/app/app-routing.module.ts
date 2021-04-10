import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BrandComponent } from './components/brand/brand.component';
import { CarImageComponent } from './components/car-image/car-image.component';
import { CarComponent } from './components/car/car.component';
import { ColorComponent } from './components/color/color.component';
import { CustomerComponent } from './components/customer/customer.component';
import { LoginComponent } from './components/login/login.component';
import { PaymentComponent } from './components/payment/payment.component';
import { RentalComponent } from './components/rental/rental.component';
import { LoginGuard } from './guards/login.guard';
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
  { path:"cars/add", component:CarComponent,canActivate:[LoginGuard]},
  { path:"cars/update", component:CarComponent,canActivate:[LoginGuard]},
  { path:"brands/add", component:BrandComponent,canActivate:[LoginGuard]},
  { path:"brands/update", component:BrandComponent,canActivate:[LoginGuard]},
  { path:"colors/add", component:ColorComponent,canActivate:[LoginGuard]},
  { path:"colors/update", component:ColorComponent,canActivate:[LoginGuard]},
  { path:"login", component:LoginComponent},
  {path:"payment",component:PaymentComponent, canActivate:[LoginGuard]},






];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
