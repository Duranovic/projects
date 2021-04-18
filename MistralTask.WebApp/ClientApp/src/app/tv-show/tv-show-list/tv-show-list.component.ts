import { ChangeDetectionStrategy, ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { debounceTime } from 'rxjs/operators';
import { ApiResponse } from 'src/app/shared/models/shared.models';

import { TwShowApiService } from '../services/tw-show-api.service';
import { TvShow } from '../tv-show';

@Component({
    selector: "tv-show-list",
    templateUrl: "tw-show-list.component.html",
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class TwShowListComponent implements OnInit {
    pageSize = 10;
    debounceTime: number = 400;
    currentPage: number = 1;
    searchControl: FormControl = new FormControl();
    errors: string[] = [];
    tvShows: ApiResponse<TvShow[]> = {} as ApiResponse<TvShow[]>;

    constructor(
        private readonly twShowApiService: TwShowApiService,
        private readonly cd: ChangeDetectorRef,
        private readonly router: Router) { }

    ngOnInit() {
        this.searchControl = new FormControl();
        this.searchControl.valueChanges
            .pipe(debounceTime(this.debounceTime))
            .subscribe(() => this.searchTvShows());
        this.getTvShows("", false);
    }

    searchTvShows(): void {
        const keyword = this.searchControl.value as string
            ? this.searchControl.value
            : "";

        if (keyword.length > 2) {
            this.getTvShows(keyword, false);
        }
    }

    pageChange(page: number): void {
        this.currentPage = page;
        this.cd.markForCheck();
        this.searchTvShows();
    }

    onSuccess(data: ApiResponse<TvShow[]>, loadMore: boolean): void {
        this.tvShows.paginationInfo = data.paginationInfo;
        if (this.tvShows.records || loadMore) {
            this.tvShows.records.push(...data.records);
        } else {
            this.tvShows.records = data.records;
        }

        this.currentPage = 1;
    }

    getTvShows(keyword: string = "", loadMore: boolean): void {
        this.twShowApiService
            .searchTvShow(keyword, this.currentPage, this.pageSize)
            .subscribe(data => this.onSuccess(data, loadMore));
    }
}