import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: "movie",
    loadChildren: () =>
      import("./movies/movies.module").then(mod => mod.MoviesModule)
  },
  {
    path: "tv-show",
    loadChildren: () =>
      import("./tv-show/tv-show.module").then(mod => mod.TwShowModule)
  },
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
