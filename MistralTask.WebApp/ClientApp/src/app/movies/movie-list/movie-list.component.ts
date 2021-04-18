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
    errors: string[] = [];
    movies: ApiResponse<Movie[]> = {} as ApiResponse<Movie[]>;
    isList: boolean = false;

    constructor(
        private readonly movieApiService: MoviesApiService,
        private readonly cd: ChangeDetectorRef,
        private readonly router: Router) { }

    ngOnInit() {
        this.searchControl = new FormControl();
        this.searchControl.valueChanges
            .pipe(debounceTime(this.debounceTime))
            .subscribe(() => this.searchMovies());
        this.getMovies("", false);
    }

    searchMovies(): void {
        const keyword = this.searchControl.value as string
            ? this.searchControl.value
            : "";

        if (keyword.length > 2) {
            this.getMovies(keyword, false);
        }
    }

    pageChange(page: number): void {
        this.currentPage = page;
        this.cd.markForCheck();
        this.searchMovies();
    }

    onSuccess(data: ApiResponse<Movie[]>, loadMore: boolean): void {
        this.movies.paginationInfo = data.paginationInfo;
        if (this.movies.records || loadMore) {
            this.movies.records.push(...data.records);
        } else{
            this.movies.records = data.records;
        }

        this.currentPage = 1;
    }

    getMovies(keyword: string = "", loadMore: boolean): void {
        if (loadMore) {
            this.currentPage++;
        }

        this.movieApiService
            .searchMovies(keyword, this.currentPage, this.pageSize)
            .subscribe(data => this.onSuccess(data, loadMore));
    }

    changeViewMode(){
        this.isList = !this.isList;
    }
}
