import {Component, OnInit, ViewChild, ElementRef} from '@angular/core';
import {HttpService} from 'src/app/services/http.service';
import {Router} from '@angular/router';
import {MatDialog, MatSnackBar} from '@angular/material';
import {isNullOrUndefined} from 'util';
import {SnackBarService} from 'src/app/services/snackBar.service';
import {environment} from 'src/environments/environment';
import {Observable} from 'rxjs';
import {RequestOptions, Request, RequestMethod} from '@angular/http';

@Component({
    selector: 'admin-drinks',
    templateUrl: './admin-drinks.component.html',
    styleUrls: ['admin-drinks.component.css'],
})
export class AdminDrinksComponent implements OnInit
{
    @ViewChild('name', {static: true}) name: TextInput;
    @ViewChild('price', {static: true}) price: TextInput;
    @ViewChild('count', {static: true}) count: TextInput;
    @ViewChild('imageUploader', {static: true}) imageUploader: ElementRef;

    public currentId: number = -1;
    public drinks: any = [];
    private image = {};
    constructor (
        private http: HttpService,
        private snackBar: SnackBarService) {}

    async ngOnInit()
    {
        await this.http.get('drink').then(data => this.drinks = data);
    }

    public async addDrink(name, price, count, image, action)
    {
        const imageUri = await this.fileUpload(image);
        if (!isNullOrUndefined(imageUri) && imageUri.hasOwnProperty('error'))
        {
            this.snackBar.openSnackBar(`Произошла ошибка при загрузке изображения`, 'Закрыть');
        }

        const response = await this.http.post('drink', this.getDrinkParams(name, price, count, imageUri));
        if (!isNullOrUndefined(response) && !response.hasOwnProperty('error'))
        {
            this.drinks.push(response);
            this.snackBar.openSnackBar(`Добавлен напиток - ${ name }`, action);
        } else
        {
            this.snackBar.openSnackBar(`Произошла ошибка при добавлении`, 'Закрыть');
        }
    }

    public async updateDrink(name, price, count, image, action)
    {
        let imageUri = {};
        if (!isNullOrUndefined(image))
        {
            imageUri = await this.fileUpload(image);
            if (!isNullOrUndefined(imageUri) && imageUri.hasOwnProperty('error'))
            {
                this.snackBar.openSnackBar(`Произошла ошибка при загрузке изображения`, 'Закрыть');
            }
        }

        const response = await this.http.put(
            'drink',
            this.getDrinkParams(name, price, count, imageUri, this.currentId));
        if (!isNullOrUndefined(response) && !response.hasOwnProperty('error'))
        {
            const drink = this.drinks.find(x => x.id == this.currentId);
            const index = this.drinks.indexOf(drink);
            
            this.drinks[index] = response;
            this.snackBar.openSnackBar(`Напиток обновлен - ${ name }`, action);
        } else
        {
            this.snackBar.openSnackBar(`Произошла ошибка при обновлении`, 'Закрыть');
        }
    }

    public setDrink(drink)
    {
        this.name.nativeElement.value = drink.name;
        this.price.nativeElement.value = drink.price;
        this.count.nativeElement.value = drink.count;
        this.imageUploader.nativeElement.value = null;
        this.currentId = drink.id;
    }

    public onElementDeleted(drink)
    {
        this.drinks = this.drinks.filter(x => x.id != drink.id);
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

    private async fileUpload(event)
    {
        const fileList: FileList = event;
        if (fileList.length > 0)
        {
            const file: File = fileList[0];
            const formData: FormData = new FormData();
            formData.append('file', file, file.name);
            const headers = new Headers();

            headers.append('Content-Type', 'multipart/form-data');
            headers.append('Accept', 'application/json');
            const options = {headers: headers};
            return await this.http.post(`imageUploader`, formData, options);
        }
    }
}
