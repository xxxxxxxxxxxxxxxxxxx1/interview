import { Component, Input, input } from '@angular/core';
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

  constructor() {}
}
