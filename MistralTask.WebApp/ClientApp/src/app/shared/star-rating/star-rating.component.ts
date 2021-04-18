import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'star-rating',
  templateUrl: './star-rating.component.html',
  styleUrls: ['./star-rating.component.scss']
})
export class StarRatingComponent implements OnInit {
  @Input() rating: number = 0;
  numbers: any[] = [];

  ngOnInit(): void {
    this.numbers = Array(this.rating).fill(this.rating - 1);
  }
}
