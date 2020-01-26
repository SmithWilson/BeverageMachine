import {Component, OnInit, Input, EventEmitter, Output} from '@angular/core';
import {HttpService} from 'src/app/services/http.service';
import {Router} from '@angular/router';
import {environment} from 'src/environments/environment';
import {isNullOrUndefined} from 'util';
import {SnackBarService} from 'src/app/services/snackBar.service';

@Component({
    selector: 'drink-card',
    templateUrl: './drink-card.component.html',
    styleUrls: ['drink-card.component.css'],
})
export class DrinkCardComponent implements OnInit
{
    @Input() drink;
    @Input() isAdmin: boolean;
    @Output() drinkDeleted: EventEmitter<any> = new EventEmitter();

    constructor (
        private http: HttpService,
        private snackBar: SnackBarService) {}

    ngOnInit()
    {

    }

    public async removeCoin(drink)
    {
        const response = await this.http.delete(`drink/${ drink.id }`);
        if (isNullOrUndefined(response))
        {
            this.drinkDeleted.emit();
            this.snackBar.openSnackBar(`Напиток ${ drink.name } - удален`, 'Закрыть');
        } else
        {
            this.snackBar.openSnackBar(`Произошла ошибка при удалении`, 'Закрыть');
        }
    }

    public getInageUri(imageUri)
    {
        return `${ environment.filesUri }${ imageUri }`;
    }
}
