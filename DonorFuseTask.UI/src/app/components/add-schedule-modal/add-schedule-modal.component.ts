import { Component, EventEmitter, Output, output } from '@angular/core';

@Component({
  selector: 'app-add-schedule-modal',
  standalone: true,
  imports: [],
  templateUrl: './add-schedule-modal.component.html',
  styleUrl: './add-schedule-modal.component.css',
})
export class AddScheduleModalComponent {
  @Output() modalClosed: EventEmitter<boolean> = new EventEmitter<boolean>();

  constructor() {}

  closeModal() {
    this.modalClosed.emit(true);
  }
}
