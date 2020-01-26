import {Component, OnInit} from '@angular/core';
import {HttpService} from 'src/app/services/http.service';
import {Router} from '@angular/router';
import {MatDialog, MatSnackBar} from '@angular/material';
import {isNullOrUndefined} from 'util';
import {SnackBarService} from 'src/app/services/snackBar.service';

@Component({
    selector: 'admin-coins',
    templateUrl: './admin-coins.component.html',
    styleUrls: ['admin-coins.component.css'],
})
export class AdminCoinsComponent implements OnInit
{

    public isActive: boolean = false;
    public coins: any = [];
    constructor (
        private http: HttpService,
        private snackBar: SnackBarService) {}

    async ngOnInit()
    {
        await this.http.get('coin').then(data => this.coins = data);
    }

    public async addCoin(par: string, action: string)
    {
        const response = await this.http.post('coin', this.getCoinParams(par, this.isActive));
        if (!isNullOrUndefined(response) && !response.hasOwnProperty('error'))
        {
            this.coins.push(response);
            this.snackBar.openSnackBar(`Добавлена монета номиналом - ${ par }`, action);
        } else
        {
            this.snackBar.openSnackBar(`Произошла ошибка при добавлении`, 'Закрыть');
        }
    }

    public async updateCoin(coin)
    {
        const response = await this.http.put('coin', this.getCoinParams(coin.par, coin.isActive, coin.id));
        if (!isNullOrUndefined(response) && !response.hasOwnProperty('error'))
        {
            this.snackBar.openSnackBar(`Обновлена монета номиналом - ${ coin.par }`, 'Закрыть');
        } else
        {
            this.snackBar.openSnackBar(`Произошла ошибка при обновлении`, 'Закрыть');
        }
    }

    public async removeCoin(coin)
    {
        const response = await this.http.delete(`coin/${ coin.id }`);
        if (isNullOrUndefined(response))
        {
            this.coins = this.coins.filter(x => x.id != coin.id);
            this.snackBar.openSnackBar(`Монета номиналом ${ coin.par } - удалена`, 'Закрыть');
        } else
        {
            this.snackBar.openSnackBar(`Произошла ошибка при удалении`, 'Закрыть');
        }
    }

    private getCoinParams(par, isActive, id = 0)
    {
        return {
            'Id': id,
            'Par': +par,
            'IsActive': isActive
        };
    }
}
