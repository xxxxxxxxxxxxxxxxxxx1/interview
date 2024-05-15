import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-add-donation-modal',
  standalone: true,
  imports: [],
  templateUrl: './add-donation-modal.component.html',
  styleUrl: './add-donation-modal.component.css',
})
export class AddDonationModalComponent {
  @Output() modalClosed: EventEmitter<boolean> = new EventEmitter<boolean>();

  constructor() {}

  closeModal() {
    this.modalClosed.emit(true);
  }
}
