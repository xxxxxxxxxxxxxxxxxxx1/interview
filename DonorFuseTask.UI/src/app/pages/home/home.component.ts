import { Component, OnInit } from '@angular/core';
import { DonorService } from '../../services/donor.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent implements OnInit {
  constructor(private donorService: DonorService) {}

  ngOnInit() {
    this.donorService.getDonors().subscribe((data) => {
      console.log(data);
    });
  }
}
