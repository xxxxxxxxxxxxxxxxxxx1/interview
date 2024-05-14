import { Injectable } from '@angular/core';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root',
})
export class ScheduleService {
  constructor(private apiService: ApiService) {}

  getSchedules() {
    return this.apiService.get('schedule');
  }

  addSchedule(data: any) {
    return this.apiService.post('schedule', data);
  }

  getSchedule(id: number) {
    return this.apiService.get(`schedule/${id}`);
  }

  updateSchedule(id: number, data: any) {
    return this.apiService.put(`schedule/${id}`, data);
  }

  deleteSchedule(id: number) {
    return this.apiService.delete(`schedule/${id}`);
  }

  getScheduleByDonorId(donorId: number) {
    return this.apiService.get(`schedule/donor/${donorId}`);
  }

  getScheduleByDonorAmount(donorId: number) {
    return this.apiService.get(`schedule/donor/${donorId}/amount`);
  }
}
