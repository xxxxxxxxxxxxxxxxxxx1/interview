import { Injectable } from '@angular/core';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root',
})
export class DonationService {
  constructor(private apiService: ApiService) {}

  getDonations() {
    return this.apiService.get('donation');
  }

  getDonation(id: number) {
    return this.apiService.get(`donation/${id}`);
  }

  deleteDonation(id: number) {
    return this.apiService.delete(`donation/${id}`);
  }

  addDonation(donorId: number, amount: number) {
    return this.apiService.post(`donation/${donorId}/${amount}`, {});
  }

  updateDonation(id: number, data: any) {
    return this.apiService.put(`donation/${id}`, data);
  }

  getTotalDonationsForDonor(donorId: number) {
    return this.apiService.get(`donation/total/${donorId}`);
  }
}
