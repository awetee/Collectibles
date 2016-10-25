import {Component, OnInit} from '@angular/core';
import {CollectibleService} from '../shared/collectible.service';
import {Observable} from 'rxjs/Observable';
import {ActivatedRoute} from '@angular/router';

@Component({
    selector: 'collectible-list',
    styleUrls: ['./collectible-list.component.css'],
    templateUrl: './collectible-list.component.html'
})
export class CollectibleListComponent implements OnInit {
    collectibles: Observable<any>;

    constructor(public collectibleService: CollectibleService) {
    }

    ngOnInit() {
        this.collectibles = this.collectibleService.getAll();
    }
}