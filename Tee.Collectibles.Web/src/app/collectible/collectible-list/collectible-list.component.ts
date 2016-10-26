import {Component, OnInit} from '@angular/core';
import {DataService} from '../../shared/data.service';
import {Observable} from 'rxjs/Observable';
import {ActivatedRoute} from '@angular/router';

@Component({
    selector: 'collectible-list',
    styleUrls: ['./collectible-list.component.css'],
    templateUrl: './collectible-list.component.html'
})
export class CollectibleListComponent implements OnInit {
    collectibles: Observable<any>;

    constructor(public collectibleService: DataService) {
    }

    ngOnInit() {
        this.collectibles = this.collectibleService.getAll();
    }
}