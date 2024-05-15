import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { DonationService } from '../../services/donation.service';

@Component({
  selector: 'app-edit-donation-modal',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './edit-donation-modal.component.html',
  styleUrl: './edit-donation-modal.component.css',
})
export class EditDonationModalComponent implements OnInit {
  @Input() donorId: number = 0;
  @Input() donationId: number = 0;
  @Output() modalClosed: EventEmitter<boolean> = new EventEmitter<boolean>();
  donationForm!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private donationService: DonationService
  ) {
    this.initDonationForm();
  }

  ngOnInit(): void {
    this.getDonation();
  }

  initDonationForm() {
    this.donationForm = this.formBuilder.group({
      amount: ['', [Validators.required]],
    });
  }

  getDonation() {
    this.donationService.getDonation(this.donationId).subscribe((donation) => {
      this.donationId = donation.id!;
      this.donationForm.patchValue({
        amount: donation.amount,
      });
    });
  }

  saveDonation() {
    if (this.donationForm.invalid || this.donationId === 0) {
      return;
    }
    const amount = this.donationForm.value.amount;

    this.donationService
      .updateDonation(this.donationId, amount)
      .subscribe(() => {
        this.closeModal();
      });
  }

  closeModal() {
    this.modalClosed.emit(true);
  }
}
