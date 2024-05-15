import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Output } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { DonorService } from '../../services/donor.service';
import { Donor } from '../../interfaces/donor';

@Component({
  selector: 'app-add-donor-modal',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './add-donor-modal.component.html',
  styleUrl: './add-donor-modal.component.css',
})
export class AddDonorModalComponent {
  @Output() modalClosed: EventEmitter<boolean> = new EventEmitter<boolean>();
  donorForm!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private donorService: DonorService
  ) {
    this.initDonorForm();
  }

  initDonorForm() {
    this.donorForm = this.formBuilder.group({
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
    });
  }

  addDonor() {
    if (this.donorForm.invalid) {
      return;
    }

    const donor: Donor = {
      firstName: this.donorForm.value.firstName,
      lastName: this.donorForm.value.lastName,
      emailAddress: this.donorForm.value.email,
    };

    this.donorService.addDonor(donor).subscribe(() => {
      this.closeModal();
    });
  }

  closeModal() {
    this.modalClosed.emit(true);
  }
}
