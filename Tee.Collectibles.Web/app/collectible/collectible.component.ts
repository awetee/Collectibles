import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../shared/data.service';

@Component({
    moduleId: module.id,
    selector: 'collectible',
    templateUrl: './collectible.component.html',
    styleUrls: ['./collectible.component.css']
})
export class CollectibleComponent {
    constructor(private router: Router, private dataService: DataService) {
    }
}