import { Car } from "./car";
import { CarImage } from "./carImage";

export interface CarDetailAndImagesDto{
    car:Car,
    carImages:CarImage[]
}