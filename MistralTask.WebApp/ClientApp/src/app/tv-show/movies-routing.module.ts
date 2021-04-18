import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { MovieListComponent } from './tv-show-list/movie-list.component';


const routes: Routes = [
    {
        path: '',
        children: [
            {
                path: "",
                redirectTo: "list",
                pathMatch: "full",
            },
            {
                path: "list",
                component: MovieListComponent,
                data: {
                    showTopTitleBar: true,
                }
            }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class UsersRoutingModule { }
