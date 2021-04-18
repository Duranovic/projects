import { ChangeDetectionStrategy, ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { debounceTime } from 'rxjs/operators';
import { ApiResponse } from 'src/app/shared/models/shared.models';

import { Movie } from '../movie';
import { MoviesApiService } from '../services/movies-api.service';

@Component({
    selector: "movie-list",
    templateUrl: "movie-list.component.html",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class MovieListComponent implements OnInit {
    pageSize = 10;
    debounceTime: number = 400;
    currentPage: number = 1;
    searchControl: FormControl = new FormControl();

    movies: ApiResponse<Movie[]> = {} as ApiResponse<Movie[]>;

    constructor(
        private readonly movieApiService: MoviesApiService,
        private readonly cd: ChangeDetectorRef,
        private readonly router: Router) { }

    ngOnInit() {
        this.searchControl = new FormControl();
        this.searchControl.valueChanges
            .pipe(debounceTime(this.debounceTime))
            .subscribe(() => this.searchMovies());
        this.searchMovies();
    }

    searchMovies(): void {
        const keyword = this.searchControl.value as string
            ? this.searchControl.value
            : "";

        if (keyword.length > 2) {
            this.getMovies(keyword);
        }
    }

    pageChange(page: number): void {
        this.currentPage = page;
        this.cd.markForCheck();
        this.searchMovies();
    }

    onSuccess(data: ApiResponse<Movie[]>): void {
        this.movies.paginationInfo = data.paginationInfo;
        this.movies.records.push(...data.records);

        this.currentPage = 1;
    }

    private getMovies(keyword: string = ""): void {
        this.movieApiService
            .searchMovies(keyword, this.currentPage, this.pageSize)
            .subscribe(data => this.onSuccess(data));
    }
}