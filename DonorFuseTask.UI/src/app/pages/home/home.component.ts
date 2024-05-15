import { Component, OnInit } from '@angular/core';
import { DonorService } from '../../services/donor.service';
import { DonorCardComponent } from '../../components/donor-card/donor-card.component';
import { DonationCardComponent } from '../../components/donation-card/donation-card.component';
import { ScheduleCardComponent } from '../../components/schedule-card/schedule-card.component';
import { Donor } from '../../interfaces/donor';
import { CommonModule } from '@angular/common';
import { Donation } from '../../interfaces/donation';
import { DonationService } from '../../services/donation.service';
import { Schedule } from '../../interfaces/schedule';
import { ScheduleService } from '../../services/schedule.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    DonorCardComponent,
    DonationCardComponent,
    ScheduleCardComponent,
    CommonModule,
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent implements OnInit {
  donors: Donor[] = [];
  donations: Donation[] = [];
  schedules: Schedule[] = [];

  selectedDonorId: number = 1;
  selectedScheduleId: number = 1;

  donationsTotal: number = 0;
  donationsTotalForSchedule: number = 0;

  constructor(
    private donorService: DonorService,
    private donationService: DonationService,
    private scheduleService: ScheduleService
  ) {}

  ngOnInit() {
    this.getPageData();
  }

  getPageData() {
    this.getDonors();
    this.getDonorDonations(this.selectedDonorId);
    this.getSchedules(this.selectedDonorId);
    this.getDonorDonationsTotal(this.selectedDonorId);
    this.getDonationsTotalForSchedule(this.selectedScheduleId);
  }

  getDonors() {
    this.donorService.getDonors().subscribe((data) => {
      this.donors = data;
    });
  }

  getDonorDonations(donorId: number) {
    this.donationService.getDonationsByDonor(donorId).subscribe((data) => {
      this.donations = data;
    });
  }

  getSchedules(donorId: number) {
    this.scheduleService.getScheduleByDonorId(donorId).subscribe((data) => {
      this.schedules = data;
    });
  }

  getDonationsTotalForSchedule(scheduleId: number) {
    if (scheduleId === 0) {
      this.donationsTotalForSchedule = 0;
      return;
    }

    this.scheduleService
      .getScheduleByDonorAmount(scheduleId)
      .subscribe((data) => {
        this.donationsTotalForSchedule = data;
      });
  }

  getDonorDonationsTotal(donorId: number) {
    this.donationService
      .getTotalDonationsForDonor(donorId)
      .subscribe((data) => {
        this.donationsTotal = data;
      });
  }

  selectDonor(donorId: number) {
    this.selectedDonorId = donorId;

    this.selectedScheduleId = 0;

    this.getDonorDonations(donorId);
    this.getSchedules(donorId);
    this.getDonorDonationsTotal(donorId);
    this.getDonationsTotalForSchedule(this.selectedScheduleId);
  }

  selectSchedule(schedule: Schedule) {
    this.selectedScheduleId = schedule.id;
    this.getDonationsTotalForSchedule(schedule.id);
  }
}
