import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {DataService} from '../../shared/data.service';
import { Router } from '@angular/router';
import { Collectible } from '../shared/Collectible';

@Component({
    selector: 'collectible-form',
    styleUrls: ['./collectible-form.component.css'],
    templateUrl: './collectible-form.component.html'
})
export class CollectibleFormComponent {
    collectibleId: Collectible;
    collectible: Collectible = new Collectible(1, 'Title', 'Description', true, 2);
    types: any =
    [
        { Id: 1, Name: "Technology" },
        { Id: 2, Name: "Brands" },
        { Id: 3, Name: "Books" },
        { Id: 4, Name: "Architecture" },
        { Id: 5, Name: "Art" },
        { Id: 6, Name: "Card" },
        { Id: 7, Name: "Aphemera" },
        { Id: 8, Name: "Clothing" },
        { Id: 9, Name: "Currency" },
        { Id: 10, Name: "Sport" }
    ];

    editing: boolean = false;

    constructor(public collectibleService: DataService, private route: ActivatedRoute, private router: Router) {
    }

    onEditing(){
        this.editing = true;
    }

    save() {
        this.collectibleService.post(this.collectible)
            .subscribe(({name}) => {
                console.log(name);
                this.router.navigate(['/collectible']);
            });
    }
}