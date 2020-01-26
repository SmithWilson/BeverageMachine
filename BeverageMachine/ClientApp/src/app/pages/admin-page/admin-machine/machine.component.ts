import {Component, OnInit, ViewChild} from '@angular/core';
import {HttpService} from 'src/app/services/http.service';
import {Router, ActivatedRoute} from '@angular/router';
import {MatDialog, MatSnackBar} from '@angular/material';
import {isNullOrUndefined} from 'util';
import {SnackBarService} from 'src/app/services/snackBar.service';

@Component({
    selector: 'admin-machine',
    templateUrl: './machine.component.html',
    styleUrls: ['machine.component.css'],
})
export class MachineComponent implements OnInit
{
    @ViewChild('count', {static: true}) count: TextInput;

    public isActive: boolean = false;
    public currentCoin = {};
    public coins: any = [];
    constructor (
        private http: HttpService,
        private snackBar: SnackBarService,
        private router: Router,
        private activeRoute: ActivatedRoute) {}

    async ngOnInit()
    {
        const key = this.activeRoute.snapshot.params['key'];
        const isValidOrStatusCode = await this.http.get(`machine/${ key }`);
       
        if(isValidOrStatusCode.status == 404)
        {
            this.router.navigate(['/']);
        }

        await this.http.get('coin').then(data => this.coins = data);
    }

    public async updateCoin(count)
    {
        if (isNullOrUndefined(this.currentCoin))
        {
            this.snackBar.openSnackBar(`Выберите монету для изменения`, 'Закрыть');
            return;
        }

        const response = await this.http.put(
            'coin',
            this.getCoinParams(this.currentCoin.par, this.isActive, count, this.currentCoin.id));
        if (!isNullOrUndefined(response) && !response.hasOwnProperty('error'))
        {
            const coin = this.coins.find(x => x.id == this.currentCoin.id);
            const index = this.coins.indexOf(coin);
            this.coins[index] = response;
            this.snackBar.openSnackBar(`Обновлена монета номиналом - ${ this.currentCoin.par }`, 'Закрыть');
        } else
        {
            this.snackBar.openSnackBar(`Произошла ошибка при обновлении`, 'Закрыть');
        }
    }

    public setCoin(coin)
    {
        this.count.nativeElement.value = coin.count;
        this.isActive = coin.isActive;
        this.currentCoin = coin;
    }

    private getCoinParams(par, isActive, count, id = 0)
    {
        return {
            'Id': id,
            'Par': +par,
            'Count': +count,
            'IsActive': isActive
        };
    }
}
