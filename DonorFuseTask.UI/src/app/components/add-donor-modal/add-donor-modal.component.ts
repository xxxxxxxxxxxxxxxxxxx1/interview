import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-add-donor-modal',
  standalone: true,
  imports: [],
  templateUrl: './add-donor-modal.component.html',
  styleUrl: './add-donor-modal.component.css',
})
export class AddDonorModalComponent {
  @Output() modalClosed: EventEmitter<boolean> = new EventEmitter<boolean>();

  constructor() {}

  closeModal() {
    this.modalClosed.emit(true);
  }
}
