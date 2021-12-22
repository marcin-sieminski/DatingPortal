import { Photo } from "./photo";

export interface RootObject {
        id: number;
        username: string;
        gender?: any;
        age: number;
        zodiacSign?: any;
        created: Date;
        lastActive: Date;
        city?: any;
        country?: any;
        growth: number;
        eyeColor?: any;
        hairColor?: any;
        martialStatus?: any;
        education?: any;
        profession?: any;
        children?: any;
        language?: any;
        motto?: any;
        description?: any;
        personality?: any;
        lookingFor?: any;
        interests?: any;
        freeTime?: any;
        sport?: any;
        movies?: any;
        music?: any;
        iLike?: any;
        iDoNotLike?: any;
        makesMeLaugh?: any;
        itFeelsBestIn?: any;
        friendsWouldDescribeMe?: any;
        photos: Photo[];
        photoUrl?: any;
    }
