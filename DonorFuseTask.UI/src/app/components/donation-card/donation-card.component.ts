import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Donation } from '../../interfaces/donation';

@Component({
  selector: 'app-donation-card',
  standalone: true,
  imports: [],
  templateUrl: './donation-card.component.html',
  styleUrl: './donation-card.component.css',
})
export class DonationCardComponent {
  @Input() donation!: Donation;
  @Output() deletedDonation: EventEmitter<number> = new EventEmitter<number>();

  constructor() {}

  deleteDonation(donationId: number) {
    this.deletedDonation.emit(donationId);
  }
}
