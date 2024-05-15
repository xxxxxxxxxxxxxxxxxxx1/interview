import { Component, EventEmitter, Input, Output, output } from '@angular/core';
import { ScheduleService } from '../../services/schedule.service';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Schedule } from '../../interfaces/schedule';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-add-schedule-modal',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './add-schedule-modal.component.html',
  styleUrl: './add-schedule-modal.component.css',
})
export class AddScheduleModalComponent {
  @Input() donorId: number = 0;
  @Output() modalClosed: EventEmitter<boolean> = new EventEmitter<boolean>();
  scheduleForm!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private scheduleService: ScheduleService
  ) {
    this.initScheduleForm();
  }

  initScheduleForm() {
    this.scheduleForm = this.formBuilder.group({
      startDate: ['', [Validators.required]],
      endDate: ['', [Validators.required]],
      amount: ['', [Validators.required]],
    });
  }

  addSchedule() {
    if (this.scheduleForm.invalid || this.donorId === 0) {
      return;
    }

    const schedule: Schedule = {
      startDate: this.scheduleForm.value.startDate,
      endDate: this.scheduleForm.value.endDate,
      amount: this.scheduleForm.value.amount,
      donorId: this.donorId,
    };

    this.scheduleService.addSchedule(schedule).subscribe(() => {
      this.closeModal();
    });
  }

  closeModal() {
    this.modalClosed.emit(true);
  }
}
