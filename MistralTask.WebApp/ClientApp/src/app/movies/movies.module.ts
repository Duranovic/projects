import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { SharedModule } from '../shared/shared.module';
import { MovieListComponent as MovieListComponent } from './movie-list/movie-list.component';
import { UsersRoutingModule as MoviesRoutingModule } from './movies-routing.module';
import { MoviesApiService } from './services/movies-api.service';

@NgModule({
    declarations: [
        MovieListComponent,
    ],
    imports: [MoviesRoutingModule, SharedModule, FormsModule, ReactiveFormsModule],
    providers: [MoviesApiService]
})
export class MoviesModule { }
