import { Component, EventEmitter, Input, Output, input } from '@angular/core';
import { Schedule } from '../../interfaces/schedule';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-schedule-card',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './schedule-card.component.html',
  styleUrl: './schedule-card.component.css',
})
export class ScheduleCardComponent {
  @Input() schedule!: Schedule;
  @Input() selectedScheduleId!: number;
  @Output() selectedSchedule: EventEmitter<number> = new EventEmitter<number>();

  constructor() {}

  selectSchedule(scheduleId: number) {
    this.selectedSchedule.emit(scheduleId);
  }
}
