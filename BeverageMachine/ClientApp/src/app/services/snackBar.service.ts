import {Injectable} from '@angular/core';
import {isNullOrUndefined, isUndefined} from 'util';
import {MatSnackBar} from '@angular/material';

@Injectable({
    providedIn: 'root'
})

export class SnackBarService
{
    constructor (private snackBar: MatSnackBar)
    {}

    public openSnackBar(message: string, action: string)
    {
        this.snackBar.open(message, action, {
            duration: 2000,
        });
    }
}