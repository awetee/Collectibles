import { Injectable } from '@angular/core';
import { Http, URLSearchParams } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class CollectibleService {
    constructor(private http: Http) { }

    getById(id: string) {
        return this.makeRequest(id);
    }

    getAll() {
        return this.makeRequest('');
    }

    private makeRequest(path: string) {
        let url = 'http://localhost:50027/api/Collectible/' + path;
        return this.http.get(url)
            .map((res) => res.json());
    }
}