import { NumberFormatStyle } from "@angular/common";

export interface Photo {
    id: number;
    url: any;
    description: any;
    dateAdded: Date;
    isMain: boolean;
    userId: NumberFormatStyle;
}
