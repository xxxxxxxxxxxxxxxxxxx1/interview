import { Injectable } from '@angular/core';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root',
})
export class DonorService {
  constructor(private apiService: ApiService) {}

  getDonors() {
    return this.apiService.get('donor');
  }

  getDonor(id: number) {
    return this.apiService.get(`donor/${id}`);
  }

  addDonor(data: any) {
    return this.apiService.post('donor', data);
  }

  updateDonor(id: number, data: any) {
    return this.apiService.put(`donor/${id}`, data);
  }

  deleteDonor(id: number) {
    return this.apiService.delete(`donor/${id}`);
  }
}
