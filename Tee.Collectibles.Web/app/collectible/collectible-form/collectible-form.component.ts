import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {DataService} from '../../shared/data.service';
import { Router } from '@angular/router';
import { Collectible } from '../shared/Collectible';

@Component({
    moduleId: module.id,
    selector: 'collectible-form',
    styleUrls: ['./collectible-form.component.css'],
    templateUrl: './collectible-form.component.html'
})
export class CollectibleFormComponent {
    collectible: Collectible = new Collectible();
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
        { Id: 10, Name: "Sport" },
        { Id: 11, Name: "Music"}
    ];

    editing: boolean = false;

    isNewCollectible = true;

    constructor(public dataService: DataService, private route: ActivatedRoute, private router: Router) {
    }

        ngOnInit() {
        this.route.params.subscribe(params => {
            let id = params['collectibleId'] || '';
            
            if(id && id > 0)
            {
                this.isNewCollectible = false;
            }

            if (!this.isNewCollectible) {
                this.dataService.getById(id)
                    .subscribe(collectibleDetails => {
                        this.collectible = new Collectible(collectibleDetails.Id, collectibleDetails.Title, collectibleDetails.Description, collectibleDetails.IsShared, collectibleDetails.TypeId);
                    });
            }
        });
    }

    save() {
        if(this.isNewCollectible){
        this.dataService.post(this.collectible)
            .subscribe(() => {
                this.router.navigate(['/collectible']);
            });
        }
        else {
            this.dataService.put(this.collectible)
            .subscribe(() => {
                this.router.navigate(['/collectible']);
            });
        }
    }
}