import { Actor } from './actor';

export interface Movie {
  id:string;
    title: string;
    releaseDate: Date;
    coverImage: string
    description: string;
    rating: number;
    actors: Actor[];
    addedStars: number;
}
