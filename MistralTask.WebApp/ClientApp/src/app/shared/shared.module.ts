import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { StarRatingComponent } from './star-rating/star-rating.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [StarRatingComponent],
  exports: [StarRatingComponent]
})
export class SharedModule { }
