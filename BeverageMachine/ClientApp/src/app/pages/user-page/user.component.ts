import {Component, OnInit} from '@angular/core';
import {HttpService} from 'src/app/services/http.service';
import {Router} from '@angular/router';
import {SnackBarService} from 'src/app/services/snackBar.service';
import {isNullOrUndefined} from 'util';

@Component({
    selector: 'user-page',
    templateUrl: './user.component.html',
})
export class UserComponent implements OnInit
{

    public balance: number = 0;
    public surrender: number = 0;
    public coins: any = [];
    public drinks: any = [];
    constructor (
        private http: HttpService,
        private snackBar: SnackBarService) {}

    async ngOnInit()
    {
        await this.http.get('coin').then(data => this.coins = data);
        await this.http.get('drink').then(data => this.drinks = data);
    }

    public async pushCoin(coin){
        this.balance += coin.par;
        coin.count += 1;
        await this.updateCoin(coin);

        this.snackBar.openSnackBar('Монета получена', 'Закрыть');
    }

    public buyDrink(drink){
        if(this.balance < drink.price){
            this.snackBar.openSnackBar('Недостаточно денег', 'Закрыть');
            return;
        }

        if(drink.count == 0){
            this.snackBar.openSnackBar('Напиток закончился', 'Закрыть');
            return;
        }

        this.balance -= drink.price;
        
        drink.count -= 1;
        this.updateDrink(drink);

        this.snackBar.openSnackBar('Напиток выдан', 'Закрыть');
    }

    public async getSurrender(){
        const surrender = await this.http.post('machine', { 'Surrender' : this.balance });
        this.balance = surrender.surrender;
        if(surrender.surrender != 0){
            this.snackBar.openSnackBar('Не хватает сдачи, купите что-то еще!', 'Закрыть');
        }
    }

    private async updateCoin(coin)
    {
        console.log(coin);
        await this.http.put(
            'coin',
            this.getCoinParams(coin.par, coin.isActive, coin.count, coin.id));
    }

    private async updateDrink(drink)
    {
        const response = await this.http.put(
            'drink',
            this.getDrinkParams(drink.name, drink.price, drink.count, drink.imageUri, drink.id));
        if (!isNullOrUndefined(response) && !response.hasOwnProperty('error'))
        {
            const index = this.drinks.indexOf(drink);

            this.drinks[index] = response;
        }
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

    private getDrinkParams(name, price, count, imageUri, id = 0)
    {
        return {
            'Id': id,
            'Name': name,
            'Price': +price,
            'Count': +count,
            'ImageUri': imageUri
        };
    }

}
