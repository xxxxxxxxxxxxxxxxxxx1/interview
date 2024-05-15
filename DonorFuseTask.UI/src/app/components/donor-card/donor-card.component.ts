import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Donor } from '../../interfaces/donor';
import { CommonModule } from '@angular/common';

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

  constructor() {}

  selectDonor(donorId: number) {
    this.selectedDonor.emit(donorId);
  }
}
