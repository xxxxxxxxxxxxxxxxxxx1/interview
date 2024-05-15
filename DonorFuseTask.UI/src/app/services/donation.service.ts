import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Observable } from 'rxjs';
import { Donation } from '../interfaces/donation';

@Injectable({
  providedIn: 'root',
})
export class DonationService {
  constructor(private apiService: ApiService) {}

  getDonations(): Observable<Donation[]> {
    return this.apiService.get('donation');
  }

  getDonation(id: number): Observable<Donation> {
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

  getDonationsByDonor(donorId: number): Observable<Donation[]> {
    return this.apiService.get(`donation/donor/${donorId}`);
  }
}
