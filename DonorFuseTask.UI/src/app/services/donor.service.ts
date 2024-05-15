import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Observable } from 'rxjs';
import { Donor } from '../interfaces/donor';

@Injectable({
  providedIn: 'root',
})
export class DonorService {
  constructor(private apiService: ApiService) {}

  getDonors(): Observable<Donor[]> {
    return this.apiService.get('donor');
  }

  getDonor(id: number): Observable<Donor> {
    return this.apiService.get(`donor/${id}`);
  }

  addDonor(data: any) {
    return this.apiService.post('donor', data);
  }

  updateDonor(id: number, data: Donor) {
    console.log(data);
    return this.apiService.put(`donor/${id}`, data);
  }

  deleteDonor(id: number) {
    return this.apiService.delete(`donor/${id}`);
  }
}
