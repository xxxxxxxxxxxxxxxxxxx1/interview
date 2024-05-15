import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Donor } from '../../interfaces/donor';
import { CommonModule } from '@angular/common';
import { DonorService } from '../../services/donor.service';

@Component({
  selector: 'app-donor-card',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './donor-card.component.html',
  styleUrl: './donor-card.component.css',
})
export class DonorCardComponent {
  @Input() donor!: Donor;
  @Input() selectedDonorId!: number;
  @Output() selectedDonor: EventEmitter<number> = new EventEmitter<number>();
  @Output() editedDonor: EventEmitter<number> = new EventEmitter<number>();
  @Output() deletedDonor: EventEmitter<number> = new EventEmitter<number>();

  constructor() {}

  selectDonor(donorId: number) {
    this.selectedDonor.emit(donorId);
  }

  editDonor(donorId: number) {
    this.editedDonor.emit(donorId);
  }

  deleteDonor(donorId: number) {
    this.deletedDonor.emit(donorId);
  }
}
