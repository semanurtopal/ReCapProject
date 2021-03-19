import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Payment } from 'src/app/models/payment';
import { PaymentService } from 'src/app/services/payment.service';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {

  constructor( private activatedRoute: ActivatedRoute,
    private toastrService: ToastrService,
    private paymentService: PaymentService) { }

  rentalId!: string;
  nameSurname!: string;
  cardNumber!: string;
  expiryDate!: string;
  cvv!: string;

  ngOnInit(): void {this.activatedRoute.params.subscribe((parameter) => {
    if (parameter['rentalId']) {
      this.rentalId = parameter['rentalId'];
    } else {
      this.toastrService.error(
        'Gerekli parametreler girilmeden ödeme yapılamaz!'
      );
    }
  });
  }

  completePayment() {
    let payment: Payment = new Payment();
    payment.rentId = this.rentalId;
    payment.nameSurname = this.nameSurname;
    payment.cardNumber = this.cardNumber;
    payment.cvv = this.cvv;
    payment.expiryDate = this.expiryDate;

    
    console.log(payment);

    this.paymentService.addPayment(payment).subscribe(
      (p) => {
        this.toastrService.success(p.message);
      },
      (error) => {
        this.toastrService.error(error.error.message);
      }
    );
  }
}