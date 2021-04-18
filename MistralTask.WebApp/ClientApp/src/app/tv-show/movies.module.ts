import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { SharedModule } from '../shared/shared.module';
import { UsersRoutingModule as MoviesRoutingModule } from './movies-routing.module';
import { MoviesApiService } from './services/movies-api.service';
import { MovieListComponent as MovieListComponent } from './tv-show-list/movie-list.component';

@NgModule({
    declarations: [
        MovieListComponent,
    ],
    imports: [MoviesRoutingModule, SharedModule, FormsModule, ReactiveFormsModule],
    providers: [MoviesApiService]
})
export class MoviesModule { }
