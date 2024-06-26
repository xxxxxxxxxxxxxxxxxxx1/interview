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
import { AddDonorModalComponent } from '../../components/add-donor-modal/add-donor-modal.component';
import { AddDonationModalComponent } from '../../components/add-donation-modal/add-donation-modal.component';
import { AddScheduleModalComponent } from '../../components/add-schedule-modal/add-schedule-modal.component';
import { EditDonorModalComponent } from '../../components/edit-donor-modal/edit-donor-modal.component';
import { EditDonationModalComponent } from '../../components/edit-donation-modal/edit-donation-modal.component';
import { EditScheduleModalComponent } from '../../components/edit-schedule-modal/edit-schedule-modal.component';

@Component({
  selector: 'app-home',
  standalone: true,
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
  imports: [
    DonorCardComponent,
    DonationCardComponent,
    ScheduleCardComponent,
    CommonModule,
    AddDonorModalComponent,
    AddDonationModalComponent,
    AddScheduleModalComponent,
    EditDonorModalComponent,
    EditDonationModalComponent,
    EditScheduleModalComponent,
  ],
})
export class HomeComponent implements OnInit {
  donors: Donor[] = [];
  donations: Donation[] = [];
  schedules: Schedule[] = [];

  selectedDonorId: number = 0;
  selectedScheduleId: number = 0;

  donationsTotal: number = 0;
  donationsTotalForSchedules: number = 0;
  donationsTotalForSchedule: number = 0;

  addDonorModalVisible: boolean = false;
  addDonationModalVisible: boolean = false;
  addScheduleModalVisible: boolean = false;

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
    this.getDonorDonationsTotalForAllSchedulesForDonor(this.selectedDonorId);
  }

  getDonors() {
    this.donorService.getDonors().subscribe((data) => {
      this.donors = data;
    });
  }

  getDonorDonations(donorId: number) {
    if (donorId === 0) {
      this.donations = [];
      return;
    }
    this.donationService.getDonationsByDonor(donorId).subscribe((data) => {
      this.donations = data;
    });
  }

  getSchedules(donorId: number) {
    if (donorId === 0) {
      this.schedules = [];
      return;
    }
    this.scheduleService.getScheduleByDonorId(donorId).subscribe((data) => {
      this.schedules = data;
    });
  }

  getDonationsTotalForSchedule(scheduleId: number) {
    this.scheduleService
      .getSingleScheduleDonorBalance(this.selectedDonorId, scheduleId)
      .subscribe((amount) => {
        this.donationsTotalForSchedule = amount;
      });
  }

  getDonorDonationsTotalForAllSchedulesForDonor(donorId: number) {
    if (donorId === 0) {
      this.donationsTotalForSchedules = 0;
      return;
    }

    this.scheduleService
      .getScheduleByDonorAmount(donorId)
      .subscribe((amount) => {
        this.donationsTotalForSchedules = amount;
      });
  }

  getDonorDonationsTotal(donorId: number) {
    if (donorId === 0) {
      this.donationsTotal = 0;
      return;
    }
    this.donationService
      .getTotalDonationsForDonor(donorId)
      .subscribe((data) => {
        this.donationsTotal = data;
      });
  }

  selectDonor(donorId: number) {
    if (this.selectedDonorId === donorId) {
      this.selectedDonorId = 0;
      this.selectedScheduleId = 0;
      this.donations = [];
      this.schedules = [];
      this.donationsTotal = 0;
      this.donationsTotalForSchedule = 0;
      return;
    }

    this.selectedDonorId = donorId;

    this.selectedScheduleId = 0;

    this.getDonorDonations(donorId);
    this.getSchedules(donorId);
    this.getDonorDonationsTotal(donorId);
    this.getDonorDonationsTotalForAllSchedulesForDonor(donorId);
  }

  selectSchedule(scheduleId: number) {
    if (this.selectedScheduleId === scheduleId) {
      this.selectedScheduleId = 0;
      this.donationsTotalForSchedule = 0;
      return;
    }

    this.selectedScheduleId = scheduleId;
    this.getDonationsTotalForSchedule(scheduleId);
  }

  deleteDonor(donorId: number) {
    this.donorService.deleteDonor(donorId).subscribe(() => {
      this.getPageData();
    });
  }

  deleteDonation(donationId: number) {
    this.donationService.deleteDonation(donationId).subscribe(() => {
      this.getPageData();
    });
  }

  deleteSchedule(scheduleId: number) {
    this.scheduleService.deleteSchedule(scheduleId).subscribe(() => {
      this.getPageData();
    });
  }

  openAddDonorModal() {
    this.addDonorModalVisible = true;
  }

  closeAddDonorModal() {
    this.addDonorModalVisible = false;
    this.getPageData();
  }

  openAddDonationModal() {
    if (this.selectedDonorId === 0) {
      return;
    }
    this.addDonationModalVisible = true;
  }

  closeAddDonationModal() {
    this.addDonationModalVisible = false;
    this.getPageData();
  }

  openAddScheduleModal() {
    if (this.selectedDonorId === 0) {
      return;
    }
    this.addScheduleModalVisible = true;
  }

  closeAddScheduleModal() {
    this.addScheduleModalVisible = false;
    this.getPageData();
  }

  editDonorModalVisible: boolean = false;

  openEditDonorModal(donorId: number) {
    this.selectedDonorId = donorId;
    this.editDonorModalVisible = true;
  }

  closeEditDonorModal() {
    this.editDonorModalVisible = false;
    this.getPageData();
  }

  editDonationModalVisible: boolean = false;
  selectedDonationId: number = 0;

  openEditDonationModal(donationId: number) {
    this.selectedDonationId = donationId;
    this.editDonationModalVisible = true;
  }

  closeEditDonationModal() {
    this.editDonationModalVisible = false;
    this.getPageData();
  }

  editScheduleModalVisible: boolean = false;

  openEditScheduleModal(scheduleId: number) {
    this.selectedScheduleId = scheduleId;
    this.editScheduleModalVisible = true;
  }

  closeEditScheduleModal() {
    this.editScheduleModalVisible = false;
    this.getPageData();
  }
}
