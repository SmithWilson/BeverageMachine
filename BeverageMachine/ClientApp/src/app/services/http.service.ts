import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {isNullOrUndefined, isUndefined} from 'util';
import {environment} from 'src/environments/environment';


@Injectable({
    providedIn: 'root'
})

export class HttpService
{
    private _client: HttpClient;
    private _options: any = {};

    constructor (client: HttpClient)
    {
        this._client = client;
    }

    async get<T>(path: string, params: string = ''): Promise<T>
    {
        if (path == null)
        {
            return null;
        }


        return await this._client.get(
            environment.endpoint + path + '?' + params,
            this.getHeaders()
        )
            .toPromise()
            .then((data) => data)
            .catch(e => e);
    }

    async post<T>(path: string, params: object, options = null): Promise<T>
    {
        if (path === null)
        {
            return null;
        }

        const response = await this._client.post(
            environment.endpoint + path,
            params,
            isNullOrUndefined(options) ? this.getHeaders() : options
        ).toPromise()
            .then(data => data)
            .catch(e => e);

        return response;
    }

    async put<T>(path: string, params: object): Promise<T>
    {
        if (path === null)
        {
            return null;
        }

        const response = await this._client.put(
            environment.endpoint + path,
            params,
            this.getHeaders()
        ).toPromise()
            .then(data => data)
            .catch(e => e);

        return response;
    }

    async delete<T>(path: string): Promise<T>
    {
        if (path === null)
        {
            return null;
        }

        const response = await this._client.delete(
            environment.endpoint + path,
            this.getHeaders()
        ).toPromise()
            .then(data => data)
            .catch(e => e);

        return response;
    }

    private getHeaders()
    {
        let headers: HttpHeaders = new HttpHeaders();
        headers = headers.set('Content-Type', 'application/json');

        this._options.headers = headers;
        return this._options;
    }
}