import { Component, Input } from '@angular/core';
import { Donor } from '../../interfaces/donor';

@Component({
  selector: 'app-donor-card',
  standalone: true,
  imports: [],
  templateUrl: './donor-card.component.html',
  styleUrl: './donor-card.component.css',
})
export class DonorCardComponent {
  @Input() donor!: Donor;

  constructor() {}
}
