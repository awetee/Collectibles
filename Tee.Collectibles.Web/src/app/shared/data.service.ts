import { Injectable } from '@angular/core';
import { Http, URLSearchParams } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class DataService {
    Url: string = 'http://localhost:50027/api/Collectible/';
    constructor(private http: Http) { }

    getById(id: string) {
        return this.get(id);
    }

    getAll() {
        return this.get('');
    }

    private get(path: string) {
        return this.http.get(this.Url + path)
            .map((res) => res.json());
    }

    post(data: any) {
        return this.http.post(this.Url, data)
            .map((res) => res.json());
    }

    put(data: any) {
        return this.http.put(this.Url, data)
            .map((res) => res.json());
    }

    delete(path: string) {
        return this.http.delete(this.Url + path)
            .map((res) => res.json());
    }

}