import { Component, EventEmitter, Input, Output } from '@angular/core';
import { DonationService } from '../../services/donation.service';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-add-donation-modal',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './add-donation-modal.component.html',
  styleUrl: './add-donation-modal.component.css',
})
export class AddDonationModalComponent {
  @Input() donorId: number = 0;
  @Output() modalClosed: EventEmitter<boolean> = new EventEmitter<boolean>();
  donationForm!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private donationService: DonationService
  ) {
    this.initDonationForm();
  }

  initDonationForm() {
    this.donationForm = this.formBuilder.group({
      amount: ['', [Validators.required]],
    });
  }

  addDonation() {
    if (this.donationForm.invalid || this.donorId === 0) {
      return;
    }
    const amount = this.donationForm.value.amount;

    this.donationService.addDonation(this.donorId, amount).subscribe(() => {
      this.closeModal();
    });
  }

  closeModal() {
    this.modalClosed.emit(true);
  }
}
