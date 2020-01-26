import {Component, OnInit} from '@angular/core';
import {HttpService} from 'src/app/services/http.service';
import {Router} from '@angular/router';

@Component({
    selector: 'admin-page',
    templateUrl: './admin.component.html',
    styleUrls: ['admin.component.css'],
})
export class AdminComponent implements OnInit
{

    constructor (private http: HttpService) {}

    ngOnInit()
    {

    }
}
