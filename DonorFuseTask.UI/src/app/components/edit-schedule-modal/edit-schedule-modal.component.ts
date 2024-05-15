import { Component, EventEmitter, Input, Output } from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  Validators,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';
import { DonationService } from '../../services/donation.service';
import { ScheduleService } from '../../services/schedule.service';
import { CommonModule } from '@angular/common';
import { Schedule } from '../../interfaces/schedule';

@Component({
  selector: 'app-edit-schedule-modal',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './edit-schedule-modal.component.html',
  styleUrl: './edit-schedule-modal.component.css',
})
export class EditScheduleModalComponent {
  @Input() scheduleId: number = 0;
  @Output() modalClosed: EventEmitter<boolean> = new EventEmitter<boolean>();
  scheduleForm!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private scheduleService: ScheduleService
  ) {
    this.initDonationForm();
  }

  ngOnInit(): void {
    this.getSchedule();
  }

  initDonationForm() {
    this.scheduleForm = this.formBuilder.group({
      startDate: ['', [Validators.required]],
      endDate: ['', [Validators.required]],
      amount: ['', [Validators.required]],
    });
  }

  getSchedule() {
    this.scheduleService.getSchedule(this.scheduleId).subscribe((schedule) => {
      this.scheduleId = schedule.id!;
      const formattedStartDate = this.formatDate(
        schedule.startDate as unknown as string
      );
      const formattedEndDate = this.formatDate(
        schedule.endDate as unknown as string
      );
      this.scheduleForm.patchValue({
        startDate: formattedStartDate,
        endDate: formattedEndDate,
        amount: schedule.amount,
      });
    });
  }

  formatDate(dateString: string): string {
    const date = new Date(dateString);
    const year = date.getFullYear();
    const month = (date.getMonth() + 1).toString().padStart(2, '0');
    const day = date.getDate().toString().padStart(2, '0');
    return `${year}-${month}-${day}`;
  }

  saveSchedule() {
    if (this.scheduleForm.invalid || this.scheduleId === 0) {
      return;
    }

    const schedule: Schedule = {
      startDate: this.scheduleForm.value.startDate,
      endDate: this.scheduleForm.value.endDate,
      amount: this.scheduleForm.value.amount,
    };

    this.scheduleService
      .updateSchedule(this.scheduleId, schedule)
      .subscribe(() => {
        this.closeModal();
      });
  }

  closeModal() {
    this.modalClosed.emit(true);
  }
}
