import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { debounceTime } from 'rxjs/operators';
import { ApiResponse } from 'src/app/shared/models/shared.models';
import { Movie } from 'src/app/tv-show/movie';
import { MoviesApiService } from '../services/movies-api.service';

@Component({
  selector: 'app-rate-movie',
  templateUrl: './rate-movie.component.html'
})
export class RateMovieComponent implements OnInit {
  movies: ApiResponse<Movie[]> = {} as ApiResponse<Movie[]>;
  addedStars: any;

  constructor(private readonly movieApiService: MoviesApiService) { }

  ngOnInit(): void {
    this.getMovies();
  }

  getMovies(): void {
    this.movieApiService
        .searchMovies("", 0, 0)
        .subscribe(data => this.onSuccess(data));
}

onSuccess(data: any): void {
  this.movies = data;
}

onAddesStars(id: string, addedStars: number): void {
  debugger;
  this.movieApiService.addStars(id, addedStars).subscribe();
}
}
