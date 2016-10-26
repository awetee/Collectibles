import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { DataService } from '../shared/data.service';

@Component({
    selector: 'collectible',
    templateUrl: './collectible.component.html',
    styleUrls: ['./collectible.component.css']
})
export class CollectibleComponent {
    constructor(private router: Router, private collectibleService: DataService) {
    }
}