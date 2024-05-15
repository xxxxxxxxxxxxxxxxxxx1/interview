import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  Validators,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';
import { Donor } from '../../interfaces/donor';
import { DonorService } from '../../services/donor.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-edit-donor-modal',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './edit-donor-modal.component.html',
  styleUrl: './edit-donor-modal.component.css',
})
export class EditDonorModalComponent implements OnInit {
  @Input() donorId: number = 0;
  @Output() modalClosed: EventEmitter<boolean> = new EventEmitter<boolean>();
  donorForm!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private donorService: DonorService
  ) {
    this.initDonorForm();
  }

  ngOnInit(): void {
    this.getDonor();
  }

  initDonorForm() {
    this.donorForm = this.formBuilder.group({
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
    });
  }

  getDonor() {
    this.donorService.getDonor(this.donorId).subscribe((donor) => {
      this.donorId = donor.id!;
      this.donorForm.patchValue({
        firstName: donor.firstName,
        lastName: donor.lastName,
        email: donor.emailAddress,
      });
    });
  }

  saveDonor() {
    if (this.donorForm.invalid || this.donorId === 0) {
      return;
    }

    const donor: Donor = {
      firstName: this.donorForm.value.firstName,
      lastName: this.donorForm.value.lastName,
      emailAddress: this.donorForm.value.email,
    };

    this.donorService.updateDonor(this.donorId, donor).subscribe(() => {
      this.closeModal();
    });
  }

  closeModal() {
    this.modalClosed.emit(true);
  }
}
